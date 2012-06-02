using System;
using tutevDataLayer.Helper;
namespace tutevDataLayer.Core {

	[Serializable]
	public class Kulup:BaseTable {

		public String Ad { get; set; }
 		public String Sifre { get; set; }
 
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
		public Kulup() {}

		public Kulup (Int32 id,String ad,String sifre) {
			this._Id=id;
			this.Ad = ad;
			this.Sifre = sifre;
		}

		public override string GetName()
		{
			return "KULUP";
		}

		public override string ToString()
		{
			return "[KULUP][KEY="+this._Id.ToString()+"], ID="+this.Id.ToString()+", AD="+this.Ad+", SIFRE="+this.Sifre+""; 
		}

	}
}
