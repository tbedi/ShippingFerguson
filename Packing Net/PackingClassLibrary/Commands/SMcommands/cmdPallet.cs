using PackingClassLibrary.CustomEntity.SMEntitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PackingClassLibrary.Commands.SMcommands
{
    public class cmdPallet
    {
        local_x3v6Entities entx3v6 = new local_x3v6Entities();

        #region setPallet
        public Guid SavePalletInfo(List<cstPalletInfo> lsPalletinfo)
        {
            Guid _return = Guid.Empty;

            try
            {
                foreach (var _palletitem in lsPalletinfo)
                {
                    PalletInfo _pallet = new PalletInfo();

                    _pallet.PalletID = Guid.NewGuid();
                    _pallet.PalletType = _palletitem.PalletType;
                    _pallet.PalletWeight = _palletitem.PalletWeight;
                    _pallet.PalletHeight = _palletitem.PalletHeight;
                    _pallet.PalletWidth = _palletitem.PalletWeight;
                    _pallet.palletCreatedTime = _palletitem.palletCreatedTime;
                    //if (_palletitem.BoxMeasurementTime.Date != Convert.ToDateTime("01/01/001").Date)
                    //{
                    //    _boxPackage.BoxMeasurementTime = _palletitem.BoxMeasurementTime;
                    //}
                    entx3v6.AddToPalletInfoes(_pallet);
                    _return = _pallet.PalletID;
                }
                entx3v6.SaveChanges();

            }
            catch (Exception)
            { }
            return _return;
        }   
        #endregion

        #region SerPalletDetail
        public Guid SavePalletDetailInfo(List<cstPalletDetails> lsPalletDetailinfo)
        {
            Guid _palletDetailID = Guid.Empty;

            try
            {
                foreach (var _palletdetailitem in lsPalletDetailinfo)
                {
                    PalletDetail _pallet = new PalletDetail();

                    _pallet.PalletDetailID = Guid.NewGuid();
                    _pallet.PalletID = _palletdetailitem.PalletID;
                    _pallet.ShipmentNumber = _palletdetailitem.ShipmentNumber;
                    _pallet.BoxNumber = _palletdetailitem.BoxNumber;
                    _pallet.CartonNumber = _palletdetailitem.CartonNumber;
                    _pallet.PrintStatus = _palletdetailitem.PrintStatus;
                    //if (_palletitem.BoxMeasurementTime.Date != Convert.ToDateTime("01/01/001").Date)
                    //{
                    //    _boxPackage.BoxMeasurementTime = _palletitem.BoxMeasurementTime;
                    //}
                    entx3v6.AddToPalletDetails(_pallet);
                    _palletDetailID = _pallet.PalletDetailID;
                }
                entx3v6.SaveChanges();

            }
            catch (Exception)
            { }
            return _palletDetailID;
        }
        #endregion

        #region GetPalletInfo
        public cstPalletInfo GetSelectedByPalletID(Guid PalletID)
        {
            cstPalletInfo _return = new cstPalletInfo();
            try
            {
                PalletInfo _palletitem = entx3v6.PalletInfoes.SingleOrDefault(i => i.PalletID == PalletID);

                cstPalletInfo _pallet = new cstPalletInfo();
                _pallet.PalletID = _pallet.PalletID;//Guid.NewGuid();
                _pallet.PalletType = _palletitem.PalletType;
                _pallet.PalletWeight = Convert.ToDouble(_palletitem.PalletWeight);
                _pallet.PalletHeight = Convert.ToDouble(_palletitem.PalletHeight);
                _pallet.PalletWidth = Convert.ToDouble(_palletitem.PalletWidth);
                _pallet.palletCreatedTime = Convert.ToDateTime(_palletitem.palletCreatedTime);
                _pallet.RowID = _palletitem.RowID;
                _pallet.PalletNumber = _palletitem.PalletNumber;
                _return = _pallet;
            }
            catch (Exception)
            { }
            return _return;
        }
        #endregion

        #region GetPalletDetail
        public cstPalletDetails GetpalletDetailsByPalletDetailID(Guid PalletDetailID)
        {
            cstPalletDetails _palletDetail = new cstPalletDetails();
            try
            {
                PalletDetail _palletitem = entx3v6.PalletDetails.SingleOrDefault(i => i.PalletDetailID == PalletDetailID);

                cstPalletDetails _pallet = new cstPalletDetails();
                _pallet.PalletID = Guid.NewGuid();
                _pallet.PalletDetailID = _palletitem.PalletDetailID;
                _pallet.BoxNumber = _palletitem.BoxNumber;
                _pallet.CartonNumber = _palletitem.CartonNumber;
                _pallet.ShipmentNumber = _palletitem.ShipmentNumber;
                _palletDetail = _pallet;
            }
            catch (Exception)
            { }
            return _palletDetail;
        }


        #endregion

    }
}
