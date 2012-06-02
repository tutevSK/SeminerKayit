using System; 
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;
using tutevDataLayer.Controller;

namespace tutevDataLayer.Core {

	public class UzmanlikAlanlariDao:BaseDbDao {

		private UzmanlikAlanlari nesne;
		private string sqlText;
		private string orderBy;
		private DbCommand dbComm = null;

		public UzmanlikAlanlariDao() {}

		public int Insert(UzmanlikAlanlari nesne,DbTransaction dbTransaction,Database db){
 			sqlText="INSERT INTO UZMANLIK_ALANLARI (UZMANLIK_ADI)VALUES(@uzmanlikAdi)SELECT @@IDENTITY";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@uzmanlikAdi", DbType.String, nesne.UzmanlikAdi==null?(object)DBNull.Value:nesne.UzmanlikAdi);
			return base.Insert(nesne, dbComm, dbTransaction, db);
		}

		public int Update(UzmanlikAlanlari nesne,DbTransaction dbTransaction,Database db){
 			sqlText=" UPDATE UZMANLIK_ALANLARI set UZMANLIK_ADI = @uzmanlikAdi WHERE ID = @id ";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@id", DbType.Int32, nesne.Id==null?(object)DBNull.Value:nesne.Id);
			db.AddInParameter(dbComm, "@uzmanlikAdi", DbType.String, nesne.UzmanlikAdi==null?(object)DBNull.Value:nesne.UzmanlikAdi);
			return base.Update(nesne, dbComm, dbTransaction, db);
		}

		public int Delete(int id,DbTransaction dbTransaction,Database db){
 			sqlText="DELETE UZMANLIK_ALANLARI where ID=@id ";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@id", DbType.Int32, id);
			UzmanlikAlanlari nesne = new UzmanlikAlanlari();
			nesne.Id = id;
			return base.Delete(nesne, dbComm, dbTransaction, db);
		}

		public UzmanlikAlanlari GetById(int id,Database db){
 			nesne = new UzmanlikAlanlari();
			sqlText="Select ID,UZMANLIK_ADI from UZMANLIK_ALANLARI where ID=@id ";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@id", DbType.Int32, id);
			using (IDataReader reader = db.ExecuteReader(dbComm)){
				if(reader.Read()){
					nesne = FillUzmanlikAlanlari(reader);
				}else nesne=null;
			}
			return nesne;
		}

		public DataSet GetAll(string OrderBy, Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select ID,UZMANLIK_ADI from UZMANLIK_ALANLARI "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			return db.ExecuteDataSet(dbComm);
		}

		public IDataReader GetAllReader(string OrderBy, Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select ID,UZMANLIK_ADI from UZMANLIK_ALANLARI "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			return db.ExecuteReader(dbComm);
		}

		public List<UzmanlikAlanlari> GetAllList(string OrderBy,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select ID,UZMANLIK_ADI from UZMANLIK_ALANLARI "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			using (IDataReader reader = db.ExecuteReader(dbComm)){
				List<UzmanlikAlanlari> uzmanlikalanlariList = new List<UzmanlikAlanlari>();
				while(reader.Read()){
					UzmanlikAlanlari uzmanlikalanlari = FillUzmanlikAlanlari(reader);
					uzmanlikalanlariList.Add( uzmanlikalanlari);
				}
				return uzmanlikalanlariList;
			}
		}

		public DataSet GetByAll(string OrderBy,String UzmanlikAdi,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText=@"Select ID,UZMANLIK_ADI from UZMANLIK_ALANLARI Where 1=1 
 						 and (UZMANLIK_ADI like @uzmanlikAdi or @uzmanlikAdi ='')
						"+orderBy;
			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@uzmanlikAdi", DbType.String, UzmanlikAdi);
			return db.ExecuteDataSet(dbComm);
		}


		public UzmanlikAlanlari FillUzmanlikAlanlari(IDataReader reader){
 			nesne = new UzmanlikAlanlari();
			nesne.Id=(Int32)reader["ID"];
			nesne.UzmanlikAdi=(String)reader["UZMANLIK_ADI"];
			return nesne;
		}
	}
}
