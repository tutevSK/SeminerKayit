using System;
using tutevDataLayer.Helper;
namespace tutevDataLayer.Core {

	[Serializable]
	public class OrganizasyonTip:BaseTable {

		public String Aciklama { get; set; }
 
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
		public OrganizasyonTip() {}

		public OrganizasyonTip (Int32 id,String aciklama) {
			this._Id=id;
			this.Aciklama = aciklama;
		}

		public override string GetName()
		{
			return "ORGANIZASYON_TIP";
		}

		public override string ToString()
		{
			return "[ORGANIZASYON_TIP][KEY="+this._Id.ToString()+"], ID="+this.Id.ToString()+", ACIKLAMA="+this.Aciklama+""; 
		}

	}
}
