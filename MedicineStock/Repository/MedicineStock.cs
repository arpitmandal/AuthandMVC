using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicineStock.MedicineStockRepository;
using MedicineStock.Models;
namespace MedicineStock.Repository
{
    public class MedicineStock :IMedicineStockRepository 
    {
        public static List<Models.MedicineStock> MedicineDetails = new List<Models.MedicineStock>() { new Models.MedicineStock{
            Name = "Aspirin",
            ChemicalComposition = "Acetylsalicyclic acid",
            TargetAilment = "General",
            DateOfExpiry= "22-10-2021",
            NumberOfTabletsInStock= 250
            },
           new Models.MedicineStock {    Name = "Codeine",
            ChemicalComposition = "serotonin",
            TargetAilment = "Orthopaedics",
            DateOfExpiry= "20-8-2021",
            NumberOfTabletsInStock= 100
             },
            new Models.MedicineStock {    Name = "Mifepristone",
            ChemicalComposition = "methotrexate",
            TargetAilment = "Gynaecology",
            DateOfExpiry= "1-1-2022",
            NumberOfTabletsInStock= 300
             },
            new Models.MedicineStock {    Name = "Combiflam",
            ChemicalComposition = "Acetaminophen",
            TargetAilment = "General",
            DateOfExpiry= "30-9-2021",
            NumberOfTabletsInStock= 150
             },
            new Models.MedicineStock {    Name = "Misoprostol",
            ChemicalComposition = "Adenylate cyclase",
            TargetAilment = "Gynaecology",
            DateOfExpiry= "22-10-2021",
            NumberOfTabletsInStock= 200
             },
            new Models.MedicineStock {    Name = "Cytotec",
            ChemicalComposition = "Myo-Inostiol,D-Chiro-Inostiol,L-Methyl Folate",
            TargetAilment = "Gynaecology ",
            DateOfExpiry= "15-5-2021",
            NumberOfTabletsInStock= 200
             }};
        public dynamic MedicineStockInformation()
        {
            return MedicineDetails.ToList();
        }
    }
}

