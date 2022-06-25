using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Project
{
    class Drug
    {
        // Id,
        //Name,
        //DrugType(syrob, powder, tablet)
        //Count,
        //PurchasePrice,
        //SalePrice
        public int Id { get; set; }
        public string Name { get; set; }
        public DrugType DrugType { get; set; }
        public int Count { get; set; }
        public int PurchasePrice { get; set; }
        public int SalePrice { get; set; }
        private int _id = 0;
        public Drug()
        {
            _id++;
            _id = Id;
        }
    }
    enum DrugType
    {
        SYROB,
        POWDER,
        TABLET
    }
}
