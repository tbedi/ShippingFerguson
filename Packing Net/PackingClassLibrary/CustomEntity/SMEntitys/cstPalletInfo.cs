using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PackingClassLibrary.CustomEntity.SMEntitys
{
    public class cstPalletInfo
    {
        public Guid PalletID { get; set; }
        public string PalletType { get; set; }
        public Double PalletWeight { get; set; }
        public Double PalletHeight { get; set; }
        public Double PalletWidth { get; set; }
        public DateTime palletCreatedTime { get; set; }
        public int RowID { get; set; }
        public string PalletNumber { get; set; }
    }
}
