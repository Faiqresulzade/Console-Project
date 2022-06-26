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
            pharamcy.employe.Add(new Employe { Name = "Faiq", Username = "superadmin", Password = "1234", RoleType = Roletypee.ADMIN });
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
                            #region AdminPanel
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
                                        goto login;
                                    case "2":
                                        AddDrug(drug, pharamcy);
                                        goto login;
                                    case "3":
                                        DeleteDrug(drug, pharamcy);
                                        goto login;
                                    case "4":
                                        EditedDrug(drug, pharamcy);
                                        goto login;
                                    case "5":
                                        DeleteEmploye(pharamcy);
                                        goto login;
                                    case "6":
                                        EditedEmploye(pharamcy);
                                        goto login;
                                }
                                break;
                            default:
                                Consolee.WriteLine("Duzgun daxil edin!!", ConsoleColor.DarkRed);
                                goto loginadmin;
                            #endregion
                            case "2":
                                SellDrug(drug, pharamcy);
                                goto login;
                            case "3":
                                goto login;
                        }
                    }
                }
            }
        }
    }
    partial class Program
    {
        #region AdminPanelMethods
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
            if (code.ToUpper() == username.ToUpper())
            {
                Consolee.WriteLine("Istifadechi adi ile kod eyni ola bilmez!!", ConsoleColor.DarkRed);
                goto inputcode;
            }
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
            if (drug.Count == 0)
            {
                Consolee.WriteLine("Derman yoxdur elave edin!!!", ConsoleColor.Red);
                return;
            }
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
            if (drug.Count == 0)
            {
                Consolee.WriteLine("Derman yoxdur ,elave edin!!", ConsoleColor.Red);
                return;
            }
            Consolee.Write("Dermanin adini daxil edin: ");
            string searcheddrug = Console.ReadLine();
            List<Drug> drugs = drug.FindAll(item => item.Name.Contains(searcheddrug));
            foreach (var item in drugs)
            {
                Consolee.WriteLine($"Adi->{item.Name}, Id-> {item.Id}, Tipi->{item.DrugType}");
            }
        inputid:
            Consolee.Write("Editlemek istediyiniz dermanin Id kodunu daxil edin: ");
            string idstr = Console.ReadLine();
            bool isint = int.TryParse(idstr, out int id);
            if (!isint)
            {
                Consolee.WriteLine("Duzgun daxil edin!!", ConsoleColor.DarkRed); goto inputid;
            }
            foreach (var item in drug)
            {
                if (item.Id == id)
                {
                    Consolee.Write("Dermanin yeni adini daxil edin: ");
                    string name = Console.ReadLine();
                inputtype:
                    Consolee.WriteLine("Dermanin novunu qeyd edin: ");
                    Consolee.WriteLine("1.SYROB");
                    Consolee.WriteLine("2.POWDER");
                    Consolee.WriteLine("3.TABLET");
                    string cavab = Console.ReadLine();
                inputqiymet:
                    Consolee.Write("Dermanin alis qiymetini daxil edin: ");
                    string qiymet = Console.ReadLine();
                    bool isintt = int.TryParse(qiymet, out int price);
                    if (!isintt)
                    {
                        Consolee.WriteLine("Duzgun daxil edin!!", ConsoleColor.Red);
                        goto inputqiymet;
                    }
                inputqiymets:
                    Consolee.Write("Dermanin satish qiymetini daxil edin: ");
                    string qiymets = Console.ReadLine();
                    bool iisintt = int.TryParse(qiymet, out int pricesale);
                    if (!iisintt)
                    {
                        Consolee.WriteLine("Duzgun daxil edin!!", ConsoleColor.Red);
                        goto inputqiymets;
                    }
                    int budce = item.SalePrice - item.PurchasePrice + pricesale - price;
                    if (budce > pharamcy.Budget)
                    {
                        Consolee.WriteLine("Budcede bu qeder pul yoxdur!!", ConsoleColor.Red);
                        goto inputqiymet;
                    }
                    item.Name = name;
                    item.PurchasePrice = price;
                    item.SalePrice = pricesale;
                    switch (cavab)
                    {
                        case "1":
                            item.DrugType = DrugType.SYROB;
                            break;
                        case "2":
                            item.DrugType = DrugType.POWDER;
                            break;
                        case "3":
                            item.DrugType = DrugType.TABLET;
                            break;
                        default:
                            Consolee.WriteLine("Duzgun daxil edin!!", ConsoleColor.Red);
                            goto inputtype;
                    }
                    pharamcy.Budget += budce;
                    Consolee.WriteFormat("Derman ugurla editlendi", ConsoleColor.DarkBlue);
                }
            }
            Consolee.WriteLine("Bele ID-li derman yoxdur!!", ConsoleColor.DarkRed);
            goto inputid;
        }
        public static void DeleteEmploye(Pharamcy pharamcy)
        {
            if (pharamcy.employe.Count == 0)
            {
                Consolee.WriteLine("Employe yoxdur!!", ConsoleColor.Red);
                return;
            }
            Consolee.Write("Silmek istediyiniz istifadechinin adini daxil edin: ");
            string name = Console.ReadLine();
            List<Employe> pharamcies = pharamcy.employe.FindAll(itemm => itemm.Name.Contains(name));
            foreach (var item in pharamcies)
            {
                Consolee.WriteLine($"AD->{item.Name}, SOYAD->{item.Surname}, ID->{item.Id}");
            }
        inputid:
            Consolee.Write("Silmek istediyiniz Employenin Id kodunu daxil edin: ");
            string idstr = Console.ReadLine();
            bool isint = int.TryParse(idstr, out int id);
            if (!isint)
            {
                Consolee.WriteLine("Duzgun daxil edin!!", ConsoleColor.DarkRed); goto inputid;
            }
            foreach (var item in pharamcy.employe)
            {
                if (item.Id == id)
                {
                    pharamcy.employe.Remove(item);
                    Consolee.WriteFormat("Employe ugurla silindi", ConsoleColor.DarkYellow);
                    return;
                }
            }
        }
        public static void EditedEmploye(Pharamcy pharamcy)
        {
            if (pharamcy.employe.Count == 0)
            {
                Consolee.WriteLine("Employe yoxdur!!", ConsoleColor.Red);
                return;
            }
            Consolee.Write("Editlemek istediyiniz istifadechinin adini daxil edin: ");
            string name = Console.ReadLine();
            List<Employe> pharamcies = pharamcy.employe.FindAll(itemm => itemm.Name.Contains(name));
            foreach (var item in pharamcies)
            {
                Consolee.WriteLine($"AD->{item.Name}, SOYAD->{item.RoleType}, ID->{item.Id}");
            }
        inputid:
            Consolee.Write("Editlemek istediyiniz Employenin Id kodunu daxil edin: ");
            string idstr = Console.ReadLine();
            bool isint = int.TryParse(idstr, out int id);
            if (!isint)
            {
                Consolee.WriteLine("Duzgun daxil edin!!", ConsoleColor.DarkRed); goto inputid;
            }
            foreach (var item in pharamcy.employe)
            {
                if (item.Id == id)
                {
                inputchange:
                    Consolee.WriteLine($"{item.Id}-Idli istifadechinin neyini editlemek isteyirsiniz");
                    Consolee.WriteLine("1.Name");
                    Consolee.WriteLine("2.Surname");
                    Consolee.WriteLine("3.RoleType");
                    Consolee.WriteLine("4.Salary");
                    Consolee.WriteLine("4.UserName");
                    Consolee.WriteLine("5.Password");
                    Consolee.WriteLine("6.Exit");
                    string result = Console.ReadLine();
                    switch (result)
                    {
                        case "1":
                            Consolee.Write("Istifadechinin yeni adini daxil edin: ");
                            item.Name = Console.ReadLine();
                            goto inputchange;
                        case "2":
                            Consolee.Write("Istifadechinin yeni adini daxil edin: ");
                            item.Surname = Console.ReadLine();
                            goto inputchange;
                        case "3":
                        inputtype:
                            Consolee.WriteLine("RoleType sechin");
                            Consolee.WriteLine("1.Admin");
                            Consolee.WriteLine("2.Staff");
                            string cavab = Console.ReadLine();
                            switch (cavab)
                            {
                                case "1":
                                    item.RoleType = Roletypee.ADMIN;
                                    goto inputchange;
                                case "2":
                                    item.RoleType = Roletypee.STAF;
                                    goto inputchange;
                                default:
                                    Consolee.WriteLine("Duzgun daxil edin!!", ConsoleColor.Red);
                                    goto inputtype;
                            }
                        case "4":
                            Consolee.Write("Yeni username daxil edin: ");
                            item.Username = Console.ReadLine();
                            goto inputchange;
                        case "5":
                        inputcode:
                            Consolee.Write("Yeni Kodu daxil edin: ");
                            string code = Console.ReadLine();
                            int count = 0;
                            if (code.Length > 4)
                            {
                                foreach (var item1 in code)
                                {
                                    for (int i = 0; i < 9; i++)
                                    {
                                        if (item1.ToString() == i.ToString())
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
                                foreach (var item1 in code)
                                {
                                    if (item1.ToString().ToUpper() == item1.ToString())
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
                            item.Password = code;
                            goto inputchange;
                        case "6":
                            Consolee.WriteFormat("Deyishiklikler ugurla sona chatdi", ConsoleColor.DarkCyan);
                            return;
                        default:
                            Consolee.WriteLine("Duzgun daxil edin!!", ConsoleColor.DarkRed);
                            goto inputchange;
                    }
                }
            }
        }
        #endregion
        public static void SellDrug(List<Drug> drug, Pharamcy pharamcy)
        {
            Consolee.Write("Dermanin adini daxil edin: ");
            string name = Console.ReadLine();
        inputdrugname:
            Consolee.WriteLine("Dermanin tipini daxil edin");
            Consolee.WriteLine("SYROB");
            Consolee.WriteLine("2.TABLET");
            Consolee.WriteLine("3.POWDER");
            string cavab = Console.ReadLine();
            bool isenum = Enum.TryParse(cavab.ToUpper(), out DrugType drug1);
            if (!isenum)
            {
                Consolee.WriteLine("Duzgun daxil edin!!", ConsoleColor.DarkRed);
                goto inputdrugname;
            }
        inputsay:
            Consolee.Write("Sayi daxil edin: ");
            string countstr = Console.ReadLine();
            bool isint = int.TryParse(countstr, out int count);
            if (!isint)
            {
                Consolee.WriteLine("Duzgun daxil edin!!", ConsoleColor.Red);
                goto inputsay;
            }
            foreach (var item in drug)
            {
                if (item.Name == name && drug1 == item.DrugType && item.Count != 0)
                {
                    Consolee.WriteLine($"ID->{item.Id}, Adi->{item.Name}, Qiymeti->{item.SalePrice}");
                inputyesorno:
                    Consolee.Write("Satish etmek istediyinizden eminmisiniz??   Yes or No :", ConsoleColor.DarkGreen);
                    string result = Console.ReadLine();
                    switch (result.ToUpper())
                    {
                        case "YES":
                            if (item.Count < count)
                            {
                            input:
                                Consolee.WriteLine($"Yalniz {item.Count} eded qalib.{item.Count} qeder isteyirsinizmi??  Yes or No");
                                string cavabb = Console.ReadLine();
                                switch (cavabb.ToUpper())
                                {
                                    case "YES":
                                        pharamcy.Budget = pharamcy.Budget + item.Count * item.SalePrice;
                                        item.Count = 0;
                                        Consolee.WriteFormat("Satish ugurla yerine yetirildi", ConsoleColor.DarkMagenta);
                                        return;
                                    case "NO":
                                        return;
                                    default:
                                        Consolee.WriteLine("Duzgun daxil edin!!", ConsoleColor.DarkRed);
                                        goto input;
                                }
                            }
                            if (item.Count >= count)
                            {
                                pharamcy.Budget = pharamcy.Budget + count * item.SalePrice;
                                item.Count = item.Count - count;
                                Consolee.WriteFormat("Satish ugurla yerine yetirildi", ConsoleColor.DarkYellow);
                                return;
                            }
                            return;
                        case "NO":
                            return;
                        default:
                            Consolee.WriteLine("Duzgun daxil edin!!", ConsoleColor.DarkRed);
                            goto inputyesorno;
                    }
                }
            }
        }
        public static void UpdateInfo(Pharamcy pharamcy)
        {

        }
    }
}
