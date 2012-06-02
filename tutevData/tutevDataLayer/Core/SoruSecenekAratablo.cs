using System;
using tutevDataLayer.Helper;
namespace tutevDataLayer.Core {

	[Serializable]
	public class SoruSecenekAratablo:BaseTable {

		public Int32 SoruId { get; set; }
 
		private Int32 _SecenekId;
		public Int32 SecenekId
		{
			get
			{
				return this._SecenekId;
			}
			set
			{
				this._SecenekId = value;
				base.PrimaryKey = this._SecenekId;
			}
		}
		public SoruSecenekAratablo() {}

		public SoruSecenekAratablo (Int32 soruId,Int32 secenekId) {
			this._SecenekId=secenekId;
			this.SoruId = soruId;
		}

		public override string GetName()
		{
			return "SORU_SECENEK_ARATABLO";
		}

		public override string ToString()
		{
			return "[SORU_SECENEK_ARATABLO][KEY="+this._SecenekId.ToString()+"], SORU_ID="+this.SoruId.ToString()+", SECENEK_ID="+this.SecenekId.ToString()+""; 
		}

	}
}
