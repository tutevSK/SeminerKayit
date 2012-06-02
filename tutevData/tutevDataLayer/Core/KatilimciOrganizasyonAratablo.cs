using System;
using tutevDataLayer.Helper;
namespace tutevDataLayer.Core {

	[Serializable]
	public class KatilimciOrganizasyonAratablo:BaseTable {

		public Int32 OrganizasyonId { get; set; }
 		public Int32 KayitNo { get; set; }
 
		private Int32 _KatilimciId;
		public Int32 KatilimciId
		{
			get
			{
				return this._KatilimciId;
			}
			set
			{
				this._KatilimciId = value;
				base.PrimaryKey = this._KatilimciId;
			}
		}
		public KatilimciOrganizasyonAratablo() {}

		public KatilimciOrganizasyonAratablo (Int32 organizasyonId,Int32 katilimciId,Int32 kayitNo) {
			this._KatilimciId=katilimciId;
			this.OrganizasyonId = organizasyonId;
			this.KayitNo = kayitNo;
		}

		public override string GetName()
		{
			return "KATILIMCI_ORGANIZASYON_ARATABLO";
		}

		public override string ToString()
		{
			return "[KATILIMCI_ORGANIZASYON_ARATABLO][KEY="+this._KatilimciId.ToString()+"], ORGANIZASYON_ID="+this.OrganizasyonId.ToString()+", KATILIMCI_ID="+this.KatilimciId.ToString()+", KAYIT_NO="+this.KayitNo.ToString()+""; 
		}

	}
}
