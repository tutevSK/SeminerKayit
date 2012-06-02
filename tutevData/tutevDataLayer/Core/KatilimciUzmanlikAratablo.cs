using System;
using tutevDataLayer.Helper;
namespace tutevDataLayer.Core {

	[Serializable]
	public class KatilimciUzmanlikAratablo:BaseTable {

		public Int32 UzmanlikAlaniId { get; set; }
 
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
		public KatilimciUzmanlikAratablo() {}

		public KatilimciUzmanlikAratablo (Int32 katilimciId,Int32 uzmanlikAlaniId) {
			this._KatilimciId=katilimciId;
			this.UzmanlikAlaniId = uzmanlikAlaniId;
		}

		public override string GetName()
		{
			return "KATILIMCI_UZMANLIK_ARATABLO";
		}

		public override string ToString()
		{
			return "[KATILIMCI_UZMANLIK_ARATABLO][KEY="+this._KatilimciId.ToString()+"], KATILIMCI_ID="+this.KatilimciId.ToString()+", UZMANLIK_ALANI_ID="+this.UzmanlikAlaniId.ToString()+""; 
		}

	}
}
