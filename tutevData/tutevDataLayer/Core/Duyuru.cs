using System;
using tutevDataLayer.Helper;
namespace tutevDataLayer.Core {

	[Serializable]
	public class Duyuru:BaseTable {

		public Int32 DuyuruTipId { get; set; }
 		public Int32 OrganizasyonId { get; set; }
 		public String Baslik { get; set; }
 		public DateTime BitisTarihi { get; set; }
 
		private Int32 _Id;
		public Int32 Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				this._Id = value;
				base.PrimaryKey = this._Id;
			}
		}
		public Duyuru() {}

		public Duyuru (Int32 id,Int32 duyuruTipId,Int32 organizasyonId,String baslik,DateTime bitisTarihi) {
			this._Id=id;
			this.DuyuruTipId = duyuruTipId;
			this.OrganizasyonId = organizasyonId;
			this.Baslik = baslik;
			this.BitisTarihi = bitisTarihi;
		}

		public override string GetName()
		{
			return "DUYURU";
		}

		public override string ToString()
		{
			return "[DUYURU][KEY="+this._Id.ToString()+"], ID="+this.Id.ToString()+", DUYURU_TIP_ID="+this.DuyuruTipId.ToString()+", ORGANIZASYON_ID="+this.OrganizasyonId.ToString()+", BASLIK="+this.Baslik+", BITIS_TARIHI="+this.BitisTarihi.ToString()+""; 
		}

	}
}
