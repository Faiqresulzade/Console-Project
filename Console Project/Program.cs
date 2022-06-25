using System;
using System.Collections.Generic;

namespace Console_Project
{
    partial class Program
    {

        public static void Main(string[] args)
        {
            List<Drug> drug = new List<Drug>();
            Pharamcy pharamcy = new Pharamcy();
            pharamcy.employe.Add(new Employe { Username = "superadmin", Password = "1234", RoleType = Roletypee.ADMIN });
        login:
            Consolee.Write("Username daxil edin: ");
            string Username = Console.ReadLine();
            Consolee.Write("Password daxil edin: ");
            string Password = Console.ReadLine();
            int count = 0;
            foreach (var item in pharamcy.employe)
            {
                if (item.Username == Username && item.Password == Password)
                {
                    count++;
                }
            }
            if (count == 0) goto login;
            if (count == 1)
            {
                foreach (var item in pharamcy.employe)
                {
                    if (Username == item.Username && Password == item.Password && item.RoleType == Roletypee.ADMIN)
                    {
                        Consolee.WriteFormat("Xosh gelmisiniz Admin", ConsoleColor.DarkGreen);
                    loginadmin:
                        Consolee.WriteLine("1.Admin Panel");
                        Consolee.WriteLine("2.Satish et");
                        Consolee.WriteLine("3.Melumatlarimi yenile");
                        string adminpanel = Console.ReadLine();

                        switch (adminpanel)
                        {
                            case "1":
                                case1:
                                Consolee.WriteLine("1.ishchi elave et");
                                Consolee.WriteLine("2.Derman elave et");
                                Consolee.WriteLine("3.Derman sil");
                                Consolee.WriteLine("4.Dermani editle");
                                Consolee.WriteLine("5.Employee sil");
                                Consolee.WriteLine("6.Employee editle");
                                string cavab = Console.ReadLine();
                                switch (cavab)
                                {
                                    case "1":
                                        AddEmploye(pharamcy);
                                        goto case1;
                                    case "2":
                                        AddDrug(drug, pharamcy);
                                        goto case1;
                                    case "3":
                                        DeleteDrug(drug, pharamcy);
                                        goto case1;
                                    case "4":
                                        break;
                                }
                                break;
                            default:
                                Consolee.WriteLine("Duzgun daxil edin!!", ConsoleColor.DarkRed);
                                goto loginadmin;
                        }
                    }
                }
            }
        }
    }
    partial class Program
    {
        public static void AddEmploye(Pharamcy pharamcy)
        {
            Consolee.Write("Ishchinin adini daxil edin: ");
            string name = Console.ReadLine();
        inputroletype:
            Consolee.WriteLine("1.RoleType=>Admin");
            Consolee.WriteLine("2.RoleType=>Staff: ");
            string roletype = Console.ReadLine();

            if (roletype != "1" && roletype != "2")
            {
                Consolee.WriteLine("Duzgun daxil edin!!", ConsoleColor.Red);
                goto inputroletype;
            }
            Consolee.Write("Soyadi daxil edin: ");
            string surname = Console.ReadLine();
        inputtime:
            Consolee.Write("Dogum gununu qeyd edin: ");
            string timestr = Console.ReadLine();
            bool istime = DateTime.TryParse(timestr, out DateTime birthDate);
            if (!istime)
            {
                Consolee.WriteLine("Duzgun daxil edin!!!", ConsoleColor.Red);
                goto inputtime;
            }
        inputmaash:
            Consolee.Write("maashi daxil edin: ");
            string maashstr = Console.ReadLine();
            bool isint = int.TryParse(maashstr, out int maash);
            if (maash < pharamcy.MinSalary)
            {
                Consolee.WriteLine("maash minumum emekhaqqindan azdir!!. Minumum emekhaqqi:200"); goto inputmaash;
            }
            if (!isint)
            {
                Consolee.WriteLine("Duzgun daxil edin!!", ConsoleColor.Red); goto inputmaash;
            }
        inputusername:
            Consolee.Write("Istifadechi adini daxil edin: ");
            string username = Console.ReadLine();
            foreach (var item in pharamcy.employe)
            {
                if (username == item.Username)
                {
                    Consolee.WriteLine("Bele istifadechi adinda istifadeci var!!", ConsoleColor.DarkRed);
                    goto inputusername;
                }
            }
        inputcode:
            Consolee.Write("Kodu daxil edin: ");
            string code = Console.ReadLine();
            int count = 0;
            if (code.Length > 4)
            {
                foreach (var item in code)
                {
                    for (int i = 0; i < 9; i++)
                    {
                        if (item.ToString() == i.ToString())
                        {
                            count++;
                        }
                    }
                }
            }
            else
            {
                Consolee.WriteLine("Kodun uzunlugu en azi 5 olmalidir!!", ConsoleColor.DarkRed); goto inputcode;
            }
            int uppercount = 0;
            if (count == 0)
            {
                Consolee.WriteLine("Kodun daxilinde en azi 1 reqem olmalidir!!", ConsoleColor.DarkRed);
                goto inputcode;
            }

            else
            {
                foreach (var item in code)
                {
                    if (item.ToString().ToUpper() == item.ToString())
                    {
                        uppercount++;
                    }
                }
            }
            if (uppercount == 0)
            {
                Consolee.WriteLine("Kodun daxilinde en azi 1 boyuk herf olmalidir!!", ConsoleColor.DarkRed);
                goto inputcode;
            }
            Employe myemploye = new Employe();
            myemploye.BirthDate = birthDate;
            myemploye.Name = name;
            myemploye.Surname = surname;
            myemploye.Username = username;
            myemploye.Salary = maash;
            if (roletype == "1")
                myemploye.RoleType = Roletypee.ADMIN;
            else myemploye.RoleType = Roletypee.STAF;

            myemploye.Password = code;
            pharamcy.employe.Add(myemploye);
            Consolee.WriteFormat("isci ugurla elave edildi", ConsoleColor.DarkBlue);

        }
        public static void AddDrug(List<Drug> drug, Pharamcy pharamcy)
        {
        inputAdddrug:
            //Adminden Name, DrugType, Count, PurchasePrice, SalePrice
            Consolee.Write("Dermanin adini daxil edin: ");
            string drugname = Console.ReadLine();
            Consolee.WriteLine("1.DrugType =>Syrob");
            Consolee.WriteLine("2.DrugType =>Powder");
            Consolee.WriteLine("3.DrugType =>Tablet");
            string result = Console.ReadLine();
        inputcount:
            Consolee.Write("Say daxil edin: ");
            string countstr = Console.ReadLine();
            bool iscount = int.TryParse(countstr, out int count);
            if (!iscount)
            {
                Consolee.WriteLine("Duzgun daxil edin!!", ConsoleColor.DarkRed);
                goto inputcount;
            }
        inputprice:
            Consolee.Write("Alis qiymetini daxil edin: ");
            string pricestr = Console.ReadLine();
            bool isprice = int.TryParse(pricestr, out int price);
            if (!isprice)
            {
                Consolee.WriteLine("Duzgun daxil edin!!", ConsoleColor.DarkRed);
                goto inputprice;
            }
        inputsaleprice:
            Consolee.Write("satis qiymetini daxil edin: ");
            string salepricestr = Console.ReadLine();
            bool issaleprice = int.TryParse(salepricestr, out int saleprice);
            if (!issaleprice)
            {
                Consolee.WriteLine("Duzgun daxil edin!!", ConsoleColor.DarkRed);
                goto inputsaleprice;
            }
            Drug drug1 = new Drug();
            drug1.Count = count;
            drug1.Name = drugname;
            drug1.PurchasePrice = price;
            drug1.SalePrice = saleprice;
            switch (result)
            {
                case "1":
                    drug1.DrugType = DrugType.SYROB;
                    break;
                case "2":
                    drug1.DrugType = DrugType.POWDER;
                    break;
                case "3":
                    drug1.DrugType = DrugType.TABLET;
                    break;
                default:
                    Consolee.WriteLine("Duzgun daxil edin!!", ConsoleColor.Red);
                    break;
            }
            int countt = 0;
            foreach (var item in drug)
            {
                if (item.Name == drugname && item.DrugType == drug1.DrugType)
                {
                    countt++;
                }
            }
            if (countt == 0)
            {
                if (price > pharamcy.Budget)
                {
                    Consolee.WriteLine("Budcede bu qeder pul yoxdur!!", ConsoleColor.DarkRed);
                   goto inputprice;
                }
                else
                {
                    pharamcy.Budget -= price;
                    drug.Add(drug1);
                    Consolee.WriteFormat("Derman elave edildi", ConsoleColor.DarkGreen);
                }
            }
            else
            {
                Consolee.WriteLine("Bu adda ve bu tipde derman var!!", ConsoleColor.Red);
                goto inputAdddrug;
            }
        }
        public static void DeleteDrug(List<Drug> drug, Pharamcy pharamcy)
        {
            Consolee.Write("Dermanin adini daxil edin: ");
            string searcheddrug = Console.ReadLine();
            List<Drug> drugs = drug.FindAll(item => item.Name.Contains(searcheddrug));
            foreach (var item in drugs)
            {
                Consolee.WriteLine($"Adi->{item.Name}, Id-> {item.Id}, Tipi->{item.DrugType}");
            }
            inputid:
            Consolee.Write("Silmek istediyiniz dermanin Id kodunu daxil edin: ");
            string idstr = Console.ReadLine();
            bool isint = int.TryParse(idstr, out int id);
            if (!isint)
            {
                Consolee.WriteLine("Duzgun dail edin!!", ConsoleColor.DarkRed); goto inputid;
            }
            foreach (var item in drug)
            {
                if (item.Id == id)
                {
                    pharamcy.Budget += item.SalePrice;
                    drug.Remove(item);
                    Consolee.WriteFormat("Derman ugurla silindi", ConsoleColor.DarkYellow);
                    return;
                }
            }
            Consolee.WriteLine("Duzgun daxil edin!!", ConsoleColor.DarkRed);
            goto inputid;
        }
        public static void EditedDrug(List<Drug> drug, Pharamcy pharamcy)
        {
            Consolee.Write("Dermanin adini daxil edin: ");
            string searcheddrug = Console.ReadLine();
            List<Drug> drugs = drug.FindAll(item => item.Name.Contains(searcheddrug));
            foreach (var item in drugs)
            {
                Consolee.WriteLine($"Adi->{item.Name}, Id-> {item.Id}, Tipi->{item.DrugType}");
            }
        inputid:
            Consolee.Write("Silmek istediyiniz dermanin Id kodunu daxil edin: ");
            string idstr = Console.ReadLine();
            bool isint = int.TryParse(idstr, out int id);
            if (!isint)
            {
                Consolee.WriteLine("Duzgun dail edin!!", ConsoleColor.DarkRed); goto inputid;
            }
        }
    }
}
