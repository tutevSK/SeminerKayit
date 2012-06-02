using System;
using tutevDataLayer.Helper;
namespace tutevDataLayer.Core {

	[Serializable]
	public class Anket:BaseTable {

		public Int32 OrganizasyonId { get; set; }
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
		public Anket() {}

		public Anket (Int32 id,Int32 organizasyonId,String aciklama) {
			this._Id=id;
			this.OrganizasyonId = organizasyonId;
			this.Aciklama = aciklama;
		}

		public override string GetName()
		{
			return "ANKET";
		}

		public override string ToString()
		{
			return "[ANKET][KEY="+this._Id.ToString()+"], ID="+this.Id.ToString()+", ORGANIZASYON_ID="+this.OrganizasyonId.ToString()+", ACIKLAMA="+this.Aciklama+""; 
		}

	}
}
