using System;
using tutevDataLayer.Helper;
namespace tutevDataLayer.Core {

	[Serializable]
	public class Organizasyon:BaseTable {

		public Int32 OrganizasyonTipId { get; set; }
 		public Int32 KulupId { get; set; }
 		public String Ad { get; set; }
 		public DateTime Tarih { get; set; }
 
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
		public Organizasyon() {}

		public Organizasyon (Int32 id,Int32 organizasyonTipId,Int32 kulupId,String ad,DateTime tarih) {
			this._Id=id;
			this.OrganizasyonTipId = organizasyonTipId;
			this.KulupId = kulupId;
			this.Ad = ad;
			this.Tarih = tarih;
		}

		public override string GetName()
		{
			return "ORGANIZASYON";
		}

		public override string ToString()
		{
			return "[ORGANIZASYON][KEY="+this._Id.ToString()+"], ID="+this.Id.ToString()+", ORGANIZASYON_TIP_ID="+this.OrganizasyonTipId.ToString()+", KULUP_ID="+this.KulupId.ToString()+", AD="+this.Ad+", TARIH="+this.Tarih.ToString()+""; 
		}

	}
}
