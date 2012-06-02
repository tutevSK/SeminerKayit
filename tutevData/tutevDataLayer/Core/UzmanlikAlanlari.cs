using System;
using tutevDataLayer.Helper;
namespace tutevDataLayer.Core {

	[Serializable]
	public class UzmanlikAlanlari:BaseTable {

		public String UzmanlikAdi { get; set; }
 
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
		public UzmanlikAlanlari() {}

		public UzmanlikAlanlari (Int32 id,String uzmanlikAdi) {
			this._Id=id;
			this.UzmanlikAdi = uzmanlikAdi;
		}

		public override string GetName()
		{
			return "UZMANLIK_ALANLARI";
		}

		public override string ToString()
		{
			return "[UZMANLIK_ALANLARI][KEY="+this._Id.ToString()+"], ID="+this.Id.ToString()+", UZMANLIK_ADI="+this.UzmanlikAdi+""; 
		}

	}
}
