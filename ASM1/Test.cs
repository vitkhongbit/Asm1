using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ASM1
{
    internal class Test
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Menu();

                string luachon = Nhapluachon();

                if (luachon == "5")
                {
                    break;
                }

                double nuocthangtruoc = Nhapluongnuoc("Nhap luong nuoc thang truoc");
                double nuocthangnay = Nhapluongnuoc("Nhap luong nuoc thang nay");

                

                Console.WriteLine("\n=========== Hoa don tien nuoc =============\n");
                Console.WriteLine("Nhap ten:");
                string name = Console.ReadLine();
                Console.WriteLine("Khach hang: " + name);
                Console.WriteLine("Luong nuoc dung thang truoc la: " + nuocthangtruoc + " (M3)");
                Console.WriteLine("Luong nuoc dung thang nay la: " + nuocthangnay + " (M3)");
                double luongnuoctieuthu = nuocthangnay - nuocthangtruoc;
                Console.WriteLine("Luong nuoc tieu thu la " + luongnuoctieuthu);

                double ketqua = Tinhtoan(luachon, nuocthangtruoc, nuocthangnay);
                Console.WriteLine("Tong so tien la: " + ketqua);

            }
            
        }

        static void Menu()
        {
            Console.WriteLine("\n====== Chuong trinh tinh tien nuoc ======");
            Console.WriteLine("Nhap theo so loai khach hang: ");
            Console.WriteLine("1. Ho gia dinh\n2. Co quan hanh chinh, dich vu cong cong\n3. Don vi san suat\n4. Dich vu kinh doanh\n5. Thoat ");
        }

        static string Nhapluachon()
        {
            string luachon = Console.ReadLine();

            while (luachon != "1" && luachon != "2" && luachon != "3" && luachon != "4" && luachon != "5")
            {
                Console.WriteLine("Nhap lai tu 1 den 5");
                luachon = Console.ReadLine();
            }
            return luachon;
        }

        static double Nhapluongnuoc(string message)
        {
            Console.WriteLine(message);
            double luongnuoc;
            while (!double.TryParse(Console.ReadLine() , out luongnuoc) || luongnuoc < 0) 
            {
                Console.WriteLine("Nhap lai " + message.ToLower());
            }
            return luongnuoc;
        }

        static double Tinhtoan (string luachon , double nuocthangtruoc , double nuocthangnay)
        {

            double tiennuocmoinguoi = 0;
            double thuemoitruong = 0;
            double luongnuoctieuthu = nuocthangnay - nuocthangtruoc;

            switch (luachon)
            {

                case "1":
                    Console.WriteLine("Khach hang la ho gia dinh:");
                    Console.WriteLine("Nhap so nguoi su dung:");
                    int nguoisudung;
                    while (!int.TryParse(Console.ReadLine(), out nguoisudung) || nguoisudung < 0)
                    {
                        Console.WriteLine("Nhap lai:");
                    }
                    double luongtieuthumoinguoi = luongnuoctieuthu / nguoisudung;
                    if (luongtieuthumoinguoi <= 10)
                    {
                        tiennuocmoinguoi = 5973;
                        thuemoitruong = 597.3;
                    }
                    else if (luongtieuthumoinguoi <= 20)
                    {
                        tiennuocmoinguoi = 7052;
                        thuemoitruong = 705.2;

                    }
                    else if (luongtieuthumoinguoi <= 30)
                    {
                        tiennuocmoinguoi = 8699;
                        thuemoitruong = 869.9;

                    }
                    else
                    {
                        tiennuocmoinguoi = 15929;
                        thuemoitruong = 1592.9;

                    }
                    break;

                case "2":
                    Console.WriteLine("Co quan hanh chinh, dich vu:");
                    tiennuocmoinguoi = 9955;
                    thuemoitruong = 995.5;


                    break;
                case "3":
                    Console.WriteLine("Don vi san suat:");
                    tiennuocmoinguoi = 11615;
                    thuemoitruong = 1161.5;

                    break;

                case "4":
                    Console.WriteLine("Dich vu kinh doanh:");
                    tiennuocmoinguoi = 22068;
                    thuemoitruong = 2206.8;
                    break;
                default:
                    Console.WriteLine("khong ton tai yeu cau");
                    break;

            }
            double tongtien = luongnuoctieuthu * (tiennuocmoinguoi + thuemoitruong);
            double vat = tongtien * 0.1;
            return tongtien + vat;
        }
        


    }
}
