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
            pharamcy.employe.Add(new Employe {Name = "Faiq", Surname="Resulzade", Genderr = Gender.MAN, Salary = 10000 ,Username = "superadmin", Password = "1234", RoleType = Roletypee.ADMIN });
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
            if (count == 0)
            {
                Consolee.WriteLine("Duzgun daxil edin!!", ConsoleColor.Red);
                goto login;
            }
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
                        Consolee.WriteLine("4.Adminleri gor");
                        Consolee.WriteLine("5.Stafflari gor");
                        Consolee.WriteLine("6.Dermanlari gor");
                        Consolee.WriteLine("7.Budceni gor");
                        Consolee.WriteLine("8.Exit");
                        string adminpanel = Console.ReadLine();
                        switch (adminpanel)
                        {
                            case "1":
                            #region AdminPanel
                            case1:
                                Consolee.WriteLine("1.ishchi elave et", ConsoleColor.DarkMagenta);
                                Consolee.WriteLine("2.Derman elave et" , ConsoleColor.DarkMagenta);
                                Consolee.WriteLine("3.Derman sil", ConsoleColor.DarkMagenta);
                                Consolee.WriteLine("4.Dermani editle", ConsoleColor.DarkMagenta);
                                Consolee.WriteLine("5.Employee sil", ConsoleColor.DarkMagenta);
                                Consolee.WriteLine("6.Employee editle", ConsoleColor.DarkMagenta);
                                Consolee.WriteLine("7.Exit", ConsoleColor.DarkMagenta);
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
                                        EditedDrug(drug, pharamcy);
                                        goto case1;
                                    case "5":
                                        DeleteEmploye(pharamcy);
                                        goto case1;
                                    case "6":
                                        EditedEmploye(pharamcy);
                                        goto case1;
                                    case "7":
                                        goto loginadmin;
                                    default:
                                        Consolee.WriteLine("Duzgun daxil edin!!", ConsoleColor.DarkRed);
                                        goto case1;
                                }
                            #endregion
                            case "2":
                                SellDrug(drug, pharamcy);
                                goto loginadmin;
                            case "3":
                                UpdateInfo(pharamcy, Username, Password);
                                goto loginadmin;
                            case "4":
                                ShowAdmins(pharamcy);
                                goto loginadmin;
                            case "5":
                                ShowStaff(pharamcy);
                                goto loginadmin;
                            case "6":
                                ShowDrugs(drug);
                                goto loginadmin;
                            case "7":
                                ShowBudget(pharamcy);
                                goto loginadmin;
                            case "8":
                              goto  login;
                            default:
                                Consolee.WriteLine("Duzgun daxil edin!!", ConsoleColor.DarkRed);
                                goto loginadmin;
                        }
                    }
                    if(Username == item.Username && Password == item.Password && item.RoleType == Roletypee.STAF)
                    {
                        Consolee.WriteFormat("Xosh gelmisiniz", ConsoleColor.DarkMagenta);
                        emplye:
                        Consolee.WriteLine("1.Satish et", ConsoleColor.DarkCyan);
                        Consolee.WriteLine("2.melumatlarimi yenile", ConsoleColor.DarkCyan);
                        Consolee.WriteLine("3.Exit", ConsoleColor.DarkCyan);
                        string cavab = Console.ReadLine();
                        switch (cavab)
                        {
                            case "1":
                                SellDrug(drug, pharamcy);
                                goto emplye;
                            case "2":
                                UpdateInfo(pharamcy,Username,Password);
                                goto emplye;
                            case "3":
                                goto login;
                            default:
                                Consolee.WriteLine("Duzgun daxil edin!!", ConsoleColor.DarkRed);
                              goto emplye;
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
            inputtname:
            Consolee.Write("Ishchinin adini daxil edin: ");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Consolee.WriteLine("Duzgun daxil edin!!", ConsoleColor.DarkRed);
                goto inputtname;
            }
        inputroletype:
            Consolee.WriteLine("1.RoleType=>Admin");
            Consolee.WriteLine("2.RoleType=>Staff: ");
            string roletype = Console.ReadLine();

            if (roletype != "1" && roletype != "2")
            {
                Consolee.WriteLine("Duzgun daxil edin!!", ConsoleColor.Red);
                goto inputroletype;
            }
            soyad:
            Consolee.Write("Soyadi daxil edin: ");
            string surname = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(surname))
            {
                Consolee.WriteLine("Duzgun daxil edin!!", ConsoleColor.DarkRed);
                goto soyad;
            }
            Consolee.WriteLine("Cinsini daxil edin");
            Consolee.WriteLine("1.MAN");
            Consolee.WriteLine("2.WOMAN");
            string cavab = Console.ReadLine();
            foreach (var item in pharamcy.employe)
            {
                switch (cavab)
                {
                    case "1":
                        item.Genderr = Gender.MAN;
                        break;
                    case "2":
                        item.Genderr = Gender.WOMAN;
                        break;
                    default:
                        Consolee.WriteLine("Duzgun daxil edin!!", ConsoleColor.Red);
                        break;
                }
            }
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
                Consolee.WriteLine("maash minumum emekhaqqindan azdir!!. Minumum emekhaqqi:200", ConsoleColor.Red); goto inputmaash;
            }
            if (!isint)
            {
                Consolee.WriteLine("Duzgun daxil edin!!", ConsoleColor.Red); goto inputmaash;
            }
        inputusername:
            Consolee.Write("Istifadechi adini daxil edin: ");
            string username = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(username))
            {
                Consolee.WriteLine("Duzgun daxil edin!!", ConsoleColor.DarkRed);
                goto inputusername;
            }
            foreach (var item in pharamcy.employe)
            {
                if (username.ToUpper() == item.Username.ToUpper())
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
                int say = 0;
                foreach (var item in code)
                {
                    if (item.ToString()== item.ToString().ToUpper())
                    {
                        uppercount++;
                    }
                   if(char.IsPunctuation(item))
                   {
                        say++;
                   }
                }
                if (say == 0)
                {
                    Consolee.WriteLine("Kodun daxilinde en azi 1 xarakter olmalidir!!", ConsoleColor.Red);
                    goto inputcode;
                }
            }
            if (uppercount <=count)
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
            if (string.IsNullOrWhiteSpace(drugname))
            {
                Consolee.WriteLine("Duzgun daxil edin!!", ConsoleColor.Red);
                goto inputAdddrug;
            }
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
            Consolee.Write("Satis qiymetini daxil edin: ");
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
                if (count * price > pharamcy.Budget)
                {
                    Consolee.WriteLine("Budcede bu qeder pul yoxdur!!", ConsoleColor.DarkRed);
                    goto inputprice;
                }
                else
                {
                    drug.Add(drug1);
                    Consolee.WriteFormat("Derman elave edildi", ConsoleColor.DarkGreen);
                    pharamcy.Budget = pharamcy.Budget - (count * price);
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
            inputname:
            Consolee.Write("Dermanin adini daxil edin: ");
            string searcheddrug = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(searcheddrug))
            {
                Consolee.WriteLine("Duzgun daxil edin!!", ConsoleColor.Red);
                goto inputname;
            }
            List<Drug> drugs = drug.FindAll(item => item.Name.ToUpper().Contains(searcheddrug.ToUpper()));
            if (drugs.Count == 0)
            {
                Consolee.WriteLine("Derman tapilmadi!!", ConsoleColor.Red);
                goto inputname;
            }
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
                Consolee.WriteLine("Duzgun daxil edin!!", ConsoleColor.DarkRed); goto inputid;
            }
            inputcount:
            Consolee.Write("Silmek istediyniz dermanin sayini daxil edin: ");
            string countstr = Console.ReadLine();
            bool iscount = int.TryParse(countstr, out int count);
            if (!iscount)
            {
                Consolee.WriteLine("Duzgun daxil edin!!", ConsoleColor.DarkRed);
                goto inputcount;
            }

            foreach (var item in drug)
            {
                if (item.Id == id)
                {
                    if (item.Count == count)
                    {
                        pharamcy.Budget += item.PurchasePrice * item.Count;
                        drug.Remove(item);
                    }
                    if (item.Count > count)
                    {
                        pharamcy.Budget += item.PurchasePrice * (item.Count - count);
                        item.Count = item.Count - count;
                    }
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
            inputname:
            Consolee.Write("Dermanin adini daxil edin: ");
            string searcheddrug = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(searcheddrug))
            {
                Consolee.WriteLine("Duzgun daxil edin!!", ConsoleColor.Red);
                goto inputname;
            }
            List<Drug> drugs = drug.FindAll(item => item.Name.ToUpper().Contains(searcheddrug.ToUpper()));
            if (drugs.Count == 0)
            {
                Consolee.WriteLine("Derman tapilmadin!!", ConsoleColor.Red);
                goto inputname;
            }
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
                    name:
                    Consolee.Write("Dermanin yeni adini daxil edin: ");
                    string name = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(name))
                    {
                        Consolee.WriteLine("Duzgun daxil edin!!", ConsoleColor.Red);
                        goto name;
                    }
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
                    bool iisintt = int.TryParse(qiymets, out int pricesale);
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
                    pharamcy.Budget -= item.PurchasePrice;
                    Consolee.WriteFormat("Derman ugurla editlendi", ConsoleColor.DarkBlue);
                    return;
                }
            }
            Consolee.WriteLine("Bele ID-li derman yoxdur!!", ConsoleColor.DarkRed);
            goto inputid;
        }
        public static void DeleteEmploye(Pharamcy pharamcy)
        {
            if (pharamcy.employe.Count == 1)
            {
                Consolee.WriteLine("Employe yoxdur!!", ConsoleColor.Red);
                return;
            }
            name:
            Consolee.Write("Silmek istediyiniz istifadechinin adini daxil edin: ");
            string name = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(name))
            {
                Consolee.WriteLine("Duzgun daxil edin!!!", ConsoleColor.Red);
                goto name;
            }
            List<Employe> pharamcies = pharamcy.employe.FindAll(itemm => itemm.Name.ToUpper().Contains(name.ToUpper()));
            if (pharamcies.Count == 0)
            {
                Consolee.WriteLine("Istifadechi tapilmadi!!", ConsoleColor.Red);
                goto name;
            }
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
            if (id == 1)
            {
                Consolee.WriteFormat("Bash admini hec kim sile bilmez!!", ConsoleColor.DarkRed);
                goto inputid;
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
            Consolee.WriteLine("Duzgun daxil edin!!", ConsoleColor.DarkRed);
            goto inputid;
        }
        public static void EditedEmploye(Pharamcy pharamcy)
        {
            if (pharamcy.employe.Count == 0)
            {
                Consolee.WriteLine("Employe yoxdur!!", ConsoleColor.Red);
                return;
            }
            inputname:
            Consolee.Write("Editlemek istediyiniz istifadechinin adini daxil edin: ");
            string name = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(name))
            {
                Consolee.WriteLine("Duzgun daxil edin!!!", ConsoleColor.Red);
                goto inputname;
            }
            List<Employe> pharamcies = pharamcy.employe.FindAll(itemm => itemm.Name.Contains(name));
            if (pharamcies.Count == 0)
            {
                Consolee.WriteLine("Istifadechi tapilmadi!!", ConsoleColor.Red);
                goto inputname;
            }
            foreach (var item in pharamcies)
            {
                Consolee.WriteLine($"AD->{item.Name}, Soyad->{item.Surname}, RoleType->{item.RoleType}, ID->{item.Id}");
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
                    Consolee.WriteLine("5.UserName");
                    Consolee.WriteLine("6.Password");
                    Consolee.WriteLine("7.Exit");
                    string result = Console.ReadLine();
                    switch (result)
                    {
                        case "1":
                            Consolee.Write("Istifadechinin yeni adini daxil edin: ");
                            string names = Console.ReadLine();
                            if (String.IsNullOrWhiteSpace(names))
                            {
                                Consolee.WriteLine("Duzgun daxil edin!!", ConsoleColor.Red);
                                goto case "1";
                            }
                            item.Name = names;
                            goto inputchange;
                        case "2":
                            Consolee.Write("Istifadechinin yeni Soyadini daxil edin: ");
                            string surname = Console.ReadLine();
                            if (String.IsNullOrWhiteSpace(surname))
                            {
                                Consolee.WriteLine("Duzgun daxil edin!!!", ConsoleColor.Red);
                                goto case "2";
                            }
                            item.Surname = surname;
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
                            Consolee.Write("Istifadechinin yeni maashini daxil edin: ");
                            string maashstr= Console.ReadLine();
                            bool ismaash = int.TryParse(maashstr, out int maash);
                            item.Salary=maash;
                            goto inputchange;
                        case "5":
                            Consolee.Write("Yeni username daxil edin: ");
                            string username = Console.ReadLine();
                            if (String.IsNullOrWhiteSpace(username))
                            {
                                Consolee.WriteLine("Duzgun daxil edin!!!", ConsoleColor.Red);
                                goto case "5";
                            }
                            item.Username = username;
                            goto inputchange;
                        case "6":
                        inputcode:
                            Consolee.Write("Yeni Kodu daxil edin: ");
                            string code = Console.ReadLine();
                            int count = 0;
                            int say = 0;
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
                                    if (char.IsPunctuation(item1))
                                    {
                                        say++;
                                    }
                                }
                                if (say == 0)
                                {
                                    Consolee.WriteLine("Kodun daxilinde en azi 1xarakter olmalidir!!", ConsoleColor.Red);
                                    goto inputcode;
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
                            if (uppercount <= 0)
                            {
                                Consolee.WriteLine("Kodun daxilinde en azi 1 boyuk herf olmalidir!!", ConsoleColor.DarkRed);
                                goto inputcode;
                            }
                            item.Password = code;
                            goto inputchange;
                        case "7":
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
            if (drug.Count == 0)
            {
                Consolee.WriteLine("Derman yoxdur!!", ConsoleColor.Red);
                return;
            }
            inputname:
            Consolee.Write("Dermanin adini daxil edin: ");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Consolee.WriteLine("Duzgun daxil edin!!", ConsoleColor.Red);
                goto inputname;
            }
        inputdrugname:
            Consolee.WriteLine("Dermanin tipini daxil edin");
            Consolee.WriteLine("SYROB");
            Consolee.WriteLine("TABLET");
            Consolee.WriteLine("POWDER");
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
            int say = 0;
            foreach (var item in drug)
            {
                if (item.Name.ToUpper() == name.ToUpper() && drug1 == item.DrugType && item.Count != 0)
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
                                        pharamcy.Budget = pharamcy.Budget + item.Count * (item.SalePrice);
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
                if (item.Count != 0)
                {
                    say++;
                }
            }
            if (say == 0)
            {
                Consolee.WriteLine("Teessufki derman qurtarib", ConsoleColor.Blue);
                return;
            }
            Consolee.WriteLine("Bele  derman yoxdur!!", ConsoleColor.Red);
        }
        public static void UpdateInfo(Pharamcy pharamcy, string username, string Password)
        {
            foreach (var item in pharamcy.employe)
            {
                if(item.Username==username&& item.Password == Password)
                {
                    inputtname:
                    Consolee.Write("Ad daxil edin: ");
                    string name = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(name))
                    {
                        Consolee.WriteLine("Duzgun daxil edin!!", ConsoleColor.DarkRed);
                        goto inputtname;
                    }
                    item.Name = name;
                    inputsoyad:
                    Consolee.Write("Soyad daxil edin: ");
                   string surname = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(surname))
                    {
                        Consolee.WriteLine("Duzgun daxil edin!!", ConsoleColor.DarkRed);
                        goto inputsoyad;
                    }
                    item.Surname = surname;
                inputusername:
                    Consolee.Write("UserName daxil edin: ");
                    string user = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(user))
                    {
                        Consolee.WriteLine("Duzgun daxil edin!!", ConsoleColor.DarkRed);
                        goto inputusername;
                    }
                    foreach (var itemname in pharamcy.employe)
                    {
                        if (user == itemname.Username)
                        {
                            Consolee.Write("Bu UserNamede istifadeci var!!", ConsoleColor.Red);
                            goto inputusername;
                        }
                    }
                    item.Username = user;
                    inputcode:
                    Consolee.Write("Kodu daxil edin: ");
                    string code = Console.ReadLine();
                    if (code.ToUpper() == username.ToUpper())
                    {
                        Consolee.WriteLine("Istifadechi adi ile kod eyni ola bilmez!!", ConsoleColor.DarkRed);
                        goto inputcode;
                    }
                    int count = 0;
                    int say = 0;
                    if (code.Length > 4)
                    {
                        foreach (var itemm in code)
                        {
                            for (int i = 0; i < 9; i++)
                            {
                                if (itemm.ToString() == i.ToString())
                                {
                                    count++;
                                }
                            }
                            if (char.IsPunctuation(itemm))
                            {
                                say++;
                            }
                        }
                        if (say == 0)
                        {
                            Consolee.WriteLine("Kodun daxilinde en azi 1 xarakter olmalidir!!", ConsoleColor.DarkRed);
                            goto inputcode;
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
                    Consolee.WriteFormat("Melumatlar ugurla yenilendi", ConsoleColor.DarkCyan);
                    return;
                }
            }
        }
        public static void ShowAdmins(Pharamcy pharamcy)
        {
            foreach (var item in pharamcy.employe)
            {
                if (item.RoleType == Roletypee.ADMIN)
                {
                    Consolee.WriteFormat($"Ad->{item.Name}, Soyad->{item.Surname}, Maas->{item.Salary}, UserName->{item.Username}, Password->{item.Password}, Id->{item.Id}", ConsoleColor.DarkMagenta);
                }
            }
        }
        public static void ShowStaff(Pharamcy pharamcy)
        {
            foreach (var item in pharamcy.employe)
            {
                if (item.RoleType == Roletypee.STAF)
                {
                    Consolee.WriteFormat($"Ad->{item.Name}, Soyad->{item.Surname}, Maas->{item.Salary}, UserName->{item.Username}, Password->{item.Password}, Id->{item.Id}", ConsoleColor.DarkMagenta);
                    return;
                }
            }
            Consolee.WriteLine("Ishchi yoxdur , zehmet olmasa Ishchi Elave edin!!", ConsoleColor.DarkRed);
        }
        public static void ShowDrugs(List<Drug> drug) 
        {
            if (drug.Count == 0)
            {
                Consolee.WriteLine("Derman yoxdur , zehmet olmasa elave edin", ConsoleColor.Red);
                return;
            }
            foreach (var item in drug)
            {
                Consolee.WriteFormat($"Ad->{item.Name}, DrugType->{item.DrugType}, Say->{item.Count}, PurchasePrice->{item.PurchasePrice}, SalePrice->{item.SalePrice}, Id->{item.Id}", ConsoleColor.DarkYellow);
            }
        }
        public static void ShowBudget(Pharamcy pharamcy)
        {
            Consolee.WriteFormat($"Budce->{pharamcy.Budget}", ConsoleColor.DarkBlue);
        }
    }
}
