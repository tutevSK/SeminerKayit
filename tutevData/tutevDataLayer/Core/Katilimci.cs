using System;
using tutevDataLayer.Helper;
namespace tutevDataLayer.Core {

	[Serializable]
	public class Katilimci:BaseTable {

		public String Ad { get; set; }
 		public String Soyad { get; set; }
 		public String Telefon { get; set; }
 		public String Email { get; set; }
 		public Int32 UnvanId { get; set; }
 
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
		public Katilimci() {}

		public Katilimci (Int32 id,String ad,String soyad,String telefon,String email,Int32 unvanId) {
			this._Id=id;
			this.Ad = ad;
			this.Soyad = soyad;
			this.Telefon = telefon;
			this.Email = email;
			this.UnvanId = unvanId;
		}

		public override string GetName()
		{
			return "KATILIMCI";
		}

		public override string ToString()
		{
			return "[KATILIMCI][KEY="+this._Id.ToString()+"], ID="+this.Id.ToString()+", AD="+this.Ad+", SOYAD="+this.Soyad+", TELEFON="+this.Telefon+", EMAIL="+this.Email+", UNVAN_ID="+this.UnvanId.ToString()+""; 
		}

	}
}
