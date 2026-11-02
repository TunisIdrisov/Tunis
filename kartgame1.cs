using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace KartTexminOyunu;

public partial class Form1 : Form
{
    private readonly Random random = new Random();
    private readonly char[] kartlar = { 'A', 'K', 'Q', 'J' };
    private readonly Dictionary<char, Image> sekiller = new Dictionary<char, Image>();
    private Image? qutuSekli;
    private Image? dogruSekli;
    private Image? sehvSekli;

    private char secilenKart;
    private int xal1 = 0;
    private int xal2 = 0;
    private int raund = 0;
    private bool acildi = false;
    private bool bitdi = false;

    public Form1()
    {
        InitializeComponent();
        SekilleriYukle();
        YeniOyun();
    }

    private Image? SekilAc(string ad)
    {
        var assembly = Assembly.GetExecutingAssembly();
        using var stream = assembly.GetManifestResourceStream("KartTexminOyunu.Assets." + ad);
        if (stream == null) return null;
        using var image = Image.FromStream(stream);
        return new Bitmap(image);
    }

    private void SekilleriYukle()
    {
        foreach (char kart in kartlar)
        {
            Image? sekil = SekilAc(kart + " kart.png");
            if (sekil != null) sekiller[kart] = sekil;
        }
        qutuSekli = SekilAc("question cub.png");
        dogruSekli = SekilAc("true.png");
        sehvSekli = SekilAc("false.png");
    }

    private void YeniOyun()
    {
        xal1 = 0;
        xal2 = 0;
        raund = 0;
        bitdi = false;
        YeniRaund();
    }

    private void YeniRaund()
    {
        if (bitdi) return;
        raund++;
        secilenKart = kartlar[random.Next(kartlar.Length)];
        acildi = false;

        txtPlayer1.Clear();
        txtPlayer2.Clear();
        txtPlayer1.Enabled = true;
        txtPlayer2.Enabled = true;
        btnPlayer1.Enabled = true;
        btnPlayer2.Enabled = true;
        btnOpen.Enabled = true;
        btnShuffle.Enabled = true;
        btnOpen.Text = "Qutunu aç";

        picDeck.Image = qutuSekli;
        picResult1.Image = null;
        picResult2.Image = null;
        lblGuess1.Text = "kart: -";
        lblGuess2.Text = "kart: -";
        lblCard.Text = "Kart: ?";
        lblRound.Text = "Raund: " + raund;
        lblMessage.Text = "";
        XallariGoster();
    }

    private void XallariGoster()
    {
        lblScore1.Text = "xal  " + xal1;
        lblScore2.Text = "xal  " + xal2;
    }

    private char? Texmin(TextBox qutu)
    {
        string daxil = qutu.Text.Trim().ToUpperInvariant();
        if (daxil.Length == 1 && kartlar.Contains(daxil[0]))
            return daxil[0];
        return null;
    }

    private void btnOpen_Click(object? sender, EventArgs e)
    {
        if (bitdi) return;

        if (acildi)
        {
            YeniRaund();
            return;
        }

        char? birinci = Texmin(txtPlayer1);
        char? ikinci = Texmin(txtPlayer2);

        if (birinci == null || ikinci == null)
        {
            MessageBox.Show("H?r iki oyunçu A, K, Q v? ya J yazmal?d?r.");
            return;
        }

        acildi = true;
        txtPlayer1.Enabled = false;
        txtPlayer2.Enabled = false;
        btnPlayer1.Enabled = false;
        btnPlayer2.Enabled = false;
        btnOpen.Text = "Növb?ti";
        lblCard.Text = "Kart: " + secilenKart;
        lblGuess1.Text = "kart: " + birinci;
        lblGuess2.Text = "kart: " + ikinci;
        picDeck.Image = sekiller.TryGetValue(secilenKart, out Image? image) ? image : null;

        bool dogru1 = birinci == secilenKart;
        bool dogru2 = ikinci == secilenKart;
        xal1 = Math.Max(0, xal1 + (dogru1 ? 1 : -1));
        xal2 = Math.Max(0, xal2 + (dogru2 ? 1 : -1));
        picResult1.Image = dogru1 ? dogruSekli : sehvSekli;
        picResult2.Image = dogru2 ? dogruSekli : sehvSekli;
        XallariGoster();

        if (xal1 >= 10 || xal2 >= 10)
        {
            bitdi = true;
            btnOpen.Enabled = false;
            btnShuffle.Enabled = false;
            string netice;
            if (xal1 >= 10 && xal2 >= 10) netice = "B?rab?rlik!";
            else if (xal1 >= 10) netice = "Oyunçu 1 uddu!";
            else netice = "Oyunçu 2 uddu!";
            lblMessage.Text = netice;
            MessageBox.Show(netice, "Oyun bitdi");
        }
    }

    private void btnShuffle_Click(object? sender, EventArgs e)
    {
        if (bitdi) return;
        if (acildi)
        {
            YeniRaund();
        }
        else
        {
            secilenKart = kartlar[random.Next(kartlar.Length)];
            lblMessage.Text = "Kartlar qar??d?r?ld?";
        }
    }

    private void btnRestart_Click(object? sender, EventArgs e) => YeniOyun();
    private void btnExit_Click(object? sender, EventArgs e) => Close();

    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        base.OnFormClosed(e);
        foreach (Image image in sekiller.Values) image.Dispose();
        qutuSekli?.Dispose();
        dogruSekli?.Dispose();
        sehvSekli?.Dispose();
    }
}