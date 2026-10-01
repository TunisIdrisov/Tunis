using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsApp4
{
    public partial class Form1 : Form
    {
        private class Food
        {
            public string Name { get; set; } = string.Empty;
            public string Emoji { get; set; } = string.Empty;
            public decimal Cost { get; set; }

            public override string ToString()
            {
                return $"{Name} - {Cost:0.00} AZN";
            }
        }

        private readonly List<Food> menu = new List<Food>
        {
            new Food { Name = "Tort",     Emoji = "🍰", Cost = 8.50m },
            new Food { Name = "Kola",     Emoji = "🥤", Cost = 1.50m },
            new Food { Name = "Kokteyl",  Emoji = "🍹", Cost = 3.25m },
            new Food { Name = "Burger",   Emoji = "🍔", Cost = 6.75m },
            new Food { Name = "Sendviç",  Emoji = "🥪", Cost = 4.00m },
            new Food { Name = "Pizza",    Emoji = "🍕", Cost = 10.00m },
            new Food { Name = "Keks",     Emoji = "🧁", Cost = 2.00m },
            new Food { Name = "Hot-doq",  Emoji = "🌭", Cost = 3.50m },
            new Food { Name = "Peçenye",  Emoji = "🍪", Cost = 1.00m }
        };

        private readonly List<Food> basket = new List<Food>();

        private Panel menuPanel = null!;
        private Panel paymentPanel = null!;
        private Panel basketPanel = null!;

        private ListBox basketBox = null!;

        private TextBox moneyBox = null!;
        private TextBox balanceBox = null!;
        private TextBox billBox = null!;

        public Form1()
        {
            InitializeComponent();

            CreateForm();
            CreatePaymentArea();
            CreateBasketArea();
            CreateMenuArea();

            Resize += FormSizeChanged;
            FormSizeChanged(null, EventArgs.Empty);
        }

        private void CreateForm()
        {
            Text = "Cafe system";
            BackColor = Color.WhiteSmoke;

            paymentPanel = new Panel
            {
                Width = 220,
                Dock = DockStyle.Left,
                BackColor = Color.LightGray
            };

            basketPanel = new Panel
            {
                Width = 220,
                Dock = DockStyle.Right,
                BackColor = Color.LightGray
            };

            menuPanel = new Panel
            {
                BackColor = Color.WhiteSmoke
            };

            Label title = new Label
            {
                Text = "MENU",
                Font = new Font(
                    "Segoe UI",
                    20,
                    FontStyle.Bold | FontStyle.Italic
                ),
                TextAlign = ContentAlignment.MiddleCenter
            };

            Controls.Add(menuPanel);
            Controls.Add(paymentPanel);
            Controls.Add(basketPanel);
            Controls.Add(title);

            title.Name = "menuTitle";
        }

        private void CreatePaymentArea()
        {
            Label cafeTitle = new Label
            {
                Text = "Cafe",
                Location = new Point(65, 10),
                AutoSize = true,
                Font = new Font(
                    "Segoe UI",
                    18,
                    FontStyle.Bold | FontStyle.Italic
                )
            };

            paymentPanel.Controls.Add(cafeTitle);

            moneyBox = MakeInput(
                paymentPanel,
                "Məbləğ:",
                285
            );

            balanceBox = MakeInput(
                paymentPanel,
                "Qalıq:",
                360
            );

            balanceBox.ReadOnly = true;

            Button calculateButton = MakeButton(
                paymentPanel,
                "Hesabla",
                10,
                430,
                Color.Green,
                200
            );

            Button clearButton = MakeButton(
                paymentPanel,
                "Təmizlə",
                10,
                480,
                Color.Red,
                200
            );

            calculateButton.Click += CalculatePayment;
            clearButton.Click += ClearPaymentFields;
        }

        private TextBox MakeInput(
            Control parent,
            string caption,
            int y)
        {
            Label label = new Label
            {
                Text = caption,
                Location = new Point(10, y),
                AutoSize = true
            };

            TextBox input = new TextBox
            {
                Location = new Point(10, y + 25),
                Width = 190
            };

            parent.Controls.Add(label);
            parent.Controls.Add(input);

            return input;
        }

        private Button MakeButton(
            Control parent,
            string text,
            int x,
            int y,
            Color color,
            int width)
        {
            Button button = new Button
            {
                Text = text,
                Location = new Point(x, y),
                Width = width,
                Height = 35,
                BackColor = color,
                ForeColor = color == Color.LightGray
                    ? Color.Black
                    : Color.White,
                FlatStyle = FlatStyle.Flat
            };

            parent.Controls.Add(button);

            return button;
        }

        private void CreateBasketArea()
        {
            Label basketTitle = new Label
            {
                Text = "Səbət",
                Location = new Point(10, 10),
                AutoSize = true,
                Font = new Font(
                    "Segoe UI",
                    14,
                    FontStyle.Bold
                )
            };

            basketPanel.Controls.Add(basketTitle);

            basketBox = new ListBox
            {
                Location = new Point(10, 45),
                Size = new Size(200, 300),
                Anchor =
                    AnchorStyles.Top |
                    AnchorStyles.Left |
                    AnchorStyles.Right
            };

            basketPanel.Controls.Add(basketBox);

            Button deleteButton = MakeButton(
                basketPanel,
                "Səbətdən sil",
                10,
                360,
                Color.LightGray,
                200
            );

            Button resetButton = MakeButton(
                basketPanel,
                "Yenilə",
                10,
                400,
                Color.LightGray,
                200
            );

            Label billLabel = new Label
            {
                Text = "Hesab:",
                Location = new Point(10, 445),
                AutoSize = true
            };

            basketPanel.Controls.Add(billLabel);

            billBox = new TextBox
            {
                Location = new Point(10, 470),
                Width = 200,
                ReadOnly = true
            };

            basketPanel.Controls.Add(billBox);

            Button totalButton = MakeButton(
                basketPanel,
                "Yekun hesab",
                10,
                510,
                Color.LightGray,
                200
            );

            deleteButton.Click += DeleteFood;
            resetButton.Click += ResetEverything;
            totalButton.Click += CalculateTotal;
        }

        private void CreateMenuArea()
        {
            for (int i = 0; i < menu.Count; i++)
            {
                Food food = menu[i];

                int column = i % 3;
                int row = i / 3;

                int startX = 15 + column * 175;
                int startY = 10 + row * 180;

                PictureBox picture = new PictureBox
                {
                    Location = new Point(startX + 10, startY),
                    Size = new Size(140, 100),
                    Tag = food,
                    Cursor = Cursors.Hand
                };

                picture.Paint += FoodPicturePaint;
                picture.Click += AddFood;

                Label foodName = new Label
                {
                    Text = food.Name,
                    Location = new Point(
                        startX,
                        startY + 105
                    ),
                    Size = new Size(160, 25),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font(
                        "Segoe UI",
                        10,
                        FontStyle.Italic
                    ),
                    Tag = food,
                    Cursor = Cursors.Hand
                };

                foodName.Click += AddFood;

                Label foodPrice = new Label
                {
                    Text = food.Cost.ToString("0.00") + " AZN",
                    Location = new Point(
                        startX,
                        startY + 130
                    ),
                    Size = new Size(160, 20),
                    TextAlign = ContentAlignment.MiddleCenter,
                    ForeColor = Color.DimGray
                };

                menuPanel.Controls.Add(picture);
                menuPanel.Controls.Add(foodName);
                menuPanel.Controls.Add(foodPrice);
            }
        }

        private void FoodPicturePaint(
            object sender,
            PaintEventArgs e)
        {
            PictureBox? box = sender as PictureBox;

            if (box == null)
                return;

            Food? selectedFood = box.Tag as Food;

            if (selectedFood == null)
                return;

            using (Font emojiFont =
                   new Font("Segoe UI Emoji", 42))
            {
                SizeF textSize =
                    e.Graphics.MeasureString(
                        selectedFood.Emoji,
                        emojiFont
                    );

                float x =
                    (box.Width - textSize.Width) / 2;

                float y =
                    (box.Height - textSize.Height) / 2;

                e.Graphics.DrawString(
                    selectedFood.Emoji,
                    emojiFont,
                    Brushes.Black,
                    x,
                    y
                );
            }
        }

        private void AddFood(
            object sender,
            EventArgs e)
        {
            Control? control = sender as Control;

            if (control == null)
                return;

            Food? selectedFood = control.Tag as Food;

            if (selectedFood == null)
                return;

            basket.Add(selectedFood);
            basketBox.Items.Add(selectedFood);
        }

        private void DeleteFood(
            object sender,
            EventArgs e)
        {
            int selectedIndex =
                basketBox.SelectedIndex;

            if (selectedIndex == -1)
                return;

            Food deletedFood =
                basket[selectedIndex];

            basket.RemoveAt(selectedIndex);
            basketBox.Items.RemoveAt(selectedIndex);

            MessageBox.Show(
                $"{deletedFood.Name} səbətdən silindi"
            );
        }

        private void ResetEverything(
            object sender,
            EventArgs e)
        {
            DialogResult answer = MessageBox.Show(
                "Xanalar sıfırlansınmı?",
                "Təsdiq",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (answer != DialogResult.Yes)
                return;

            basket.Clear();
            basketBox.Items.Clear();

            moneyBox.Clear();
            balanceBox.Clear();
            billBox.Clear();
        }

        private void CalculateTotal(
            object sender,
            EventArgs e)
        {
            if (basket.Count == 0)
            {
                MessageBox.Show(
                    "Səbətdə yemək yoxdur!"
                );

                return;
            }

            decimal totalPrice =
                basket.Sum(food => food.Cost);

            billBox.Text =
                totalPrice.ToString("0.00");
        }

        private void CalculatePayment(
            object sender,
            EventArgs e)
        {
            decimal total;

            if (!decimal.TryParse(
                    billBox.Text,
                    NumberStyles.Number,
                    CultureInfo.CurrentCulture,
                    out total)
                || total <= 0)
            {
                MessageBox.Show(
                    "Əvvəlcə yekun hesabı hesablayın."
                );

                return;
            }

            decimal customerMoney;

            if (!decimal.TryParse(
                    moneyBox.Text,
                    NumberStyles.Number,
                    CultureInfo.CurrentCulture,
                    out customerMoney))
            {
                MessageBox.Show(
                    "Düzgün məbləğ daxil edin."
                );

                return;
            }

            if (customerMoney < total)
            {
                MessageBox.Show(
                    "Daxil edilən məbləğ hesabdan azdır"
                );

                return;
            }

            decimal change =
                customerMoney - total;

            balanceBox.Text =
                change.ToString("0.00");
        }

        private void ClearPaymentFields(
            object sender,
            EventArgs e)
        {
            moneyBox.Clear();
            balanceBox.Clear();
        }

        private void FormSizeChanged(
            object? sender,
            EventArgs e)
        {
            int leftWidth =
                paymentPanel.Width;

            int rightWidth =
                basketPanel.Width;

            int centerWidth =
                ClientSize.Width
                - leftWidth
                - rightWidth;

            if (centerWidth < 520)
                centerWidth = 520;

            menuPanel.SetBounds(
                leftWidth,
                50,
                centerWidth,
                Math.Max(
                    540,
                    ClientSize.Height - 50
                )
            );

            Label? title = Controls
                .OfType<Label>()
                .FirstOrDefault(
                    x => x.Name == "menuTitle"
                );

            if (title != null)
            {
                title.SetBounds(
                    leftWidth,
                    0,
                    centerWidth,
                    50
                );
            }
        }

        private void Form1_Load(
            object sender,
            EventArgs e)
        {
        }
    }
}