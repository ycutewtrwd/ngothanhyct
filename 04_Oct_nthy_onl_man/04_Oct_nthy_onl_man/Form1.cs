using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _04_Oct_nthy_onl_man
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int giatri(string huongdan)
        {
            int gt = 0;
            Form2 f =new Form2();
            f.lblnhap.Text = huongdan;
            f.ShowDialog();
            gt = int.Parse(f.txtnhap.Text);
            return gt;
        }
        
        int[]A;
        void nhapmang(int[] a)
        {
            Random x = new Random();
            for(int i=0;i < a.Length;i++)
            {
                a[i] = x.Next(1,90);
            }
        }
        string xuatmang(int[] a)
        {
            string chuoimang="";
            foreach(int x in a)
                chuoimang = chuoimang + x +" ";
            return chuoimang;
        }
        string xuatsonguyento(int[] a)
        {
            string chuoimang = "";
            foreach (int x in a)
                if(ktsonguyento(x))
                chuoimang += x + " ";
                return chuoimang;
        }
        long tongmang(int[] a)
        {
            long kq = 0;
            foreach(int x in a)
                kq= kq + x;
            return kq;
        }
        private void btnmangmoi_Click(object sender, EventArgs e)
        {
            int n = giatri("nhap so phan tu");
            A = new int[n];
            lblkq.Text = n.ToString();
            nhapmang(A);
            lblmanggoc.Text = xuatmang(A);
            xulybutton(false);

        }

        private void btntongmang_Click(object sender, EventArgs e)
        {
            lblkq.Text = tongmang(A).ToString();
        }
        int timgiatritrongmang(int[] a,int t)
        {
          // khooing tim thay vi tri
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == t)
                    return i;
            }
                return-1;
        }
        private void btntimkiem_Click(object sender, EventArgs e)
        {
            int t = giatri("nhap gia tri can tim");
            int vitri = timgiatritrongmang(A, t);
            if(vitri == -1)
            {
                lblkq.Text = "khong tim thay gia tri i";
            }
            else
            {
                lblkq.Text = "tim thay tai tri tri "+(vitri+1).ToString();
            }
        }
        Boolean ktsonguyento(int n)
        {
            for (int i = 2; i < n / 2; i++)
                if (n % i == 0)
                    return false;
            return true;
        }
        int demsonguyento(int[] a)
        {
            int dem = 0;
            for(int i = 0; i < a.Length; i++)
                if (ktsonguyento(a[i])==true)
                {
                    dem++;
                }
            return dem;
        }
        void xulybutton(Boolean t)
        {
            btnmangmoi.Enabled = t;
            btnclear.Enabled = !t;
            btntimkiem.Enabled = !t;
            btntongchan.Enabled = !t;
            btntongle.Enabled = !t;
            btndemsochan.Enabled = !t;
            btntongmang.Enabled = !t;
            btnmax.Enabled = !t;
            btnmin.Enabled = !t;
            btndaonguoc.Enabled = !t;
            btndemsnto.Enabled = !t;
            btnsnguyento.Enabled = !t;
            btndemsole.Enabled = !t;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            xulybutton(true);
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            xulybutton(true);
            lblkq.Text = "";
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        int tongchan(int[] a)
        { 
            int tong = 0;
           for(int i=0;i<a.Length; i++)
                if(a[i]%2==0)
                    tong += a[i];
            return tong;
        }
        int tongle(int[] a)
        {
            int tong = 0;
            for (int i = 0; i < a.Length; i++)
                if (a[i] % 2 != 0)
                    tong += a[i];
            return tong;
        }
        private void btntongchan_Click(object sender, EventArgs e)
        {
            lblkq.Text = tongchan(A).ToString();
        }

        private void btntongle_Click(object sender, EventArgs e)
        {
            lblkq.Text = tongle(A).ToString();
        }
        int demsochan(int[] a)
        {
            int demso = 0;
            for(int i=0; i<a.Length; i++)
           if(a[i]%2==0)
                demso++;
            return demso;
        }
        int demsole(int[] a)
        {
            int demso = 0;
            for (int i = 0; i < a.Length; i++)
                if (a[i] % 2 != 0)
                    demso++;
            return demso;
        }
        private void btndemsochan_Click(object sender, EventArgs e)
        {
            lblkq.Text=demsochan(A).ToString();
        }

        private void btndemsole_Click(object sender, EventArgs e)
        {
            lblkq.Text = demsole(A).ToString();
        }
        int timmax(int[] a)
        {
            int max = a[0];
            foreach (int x in a )
            if(x > max)
                    max = x;
            return max;
        }
        int timmin(int[] a)
        {
            int min = a[0];
            foreach (int x in a)
                if (x < min)
                    min = x;
            return min;
        }
        private void btnmax_Click(object sender, EventArgs e)
        {
            lblkq.Text = timmax(A).ToString();
        }

        private void btnmin_Click(object sender, EventArgs e)
        {
            lblkq.Text = timmin(A).ToString();
        }

        private void btndemsnto_Click(object sender, EventArgs e)
        {
            lblkq.Text=demsonguyento(A).ToString();
        }

        private void btnsnguyento_Click(object sender, EventArgs e)
        {
            lblkq.Text = xuatsonguyento(A).ToString();
        }
        void daonguocdayso(int[] a)
        {
            int j = a.Length-1;
            int i = 0;
            do
            {
                int t = a[i];
                a[i] = a[j];
                a[j] = t;
                i++; j--;
            }
            while (i < (a.Length) / 2);

        }
        int Tim(int[] a, int gt)
        {
            int i, vt = -1;
            for (i = 0; i < a.Length; i++)
            {
                if (a[i] == gt)
                {
                    vt = i;
                    break;
                }
            }
            return vt;
        }
        private void btndaonguoc_Click(object sender, EventArgs e)
        {
            daonguocdayso(A);
            lblkq.Text = xuatmang(A);
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            int  gt, vt;
            gt = giatri("nhập vào số cần xóa");
            vt = timgiatritrongmang(A, gt);
            for (int i = vt; i < A.Length - 1; i++)
                A[i] = A[i + 1];
            lblkq.Text=xuatmang(A);
        }
    }
}
