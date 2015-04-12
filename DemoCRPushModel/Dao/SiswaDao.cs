using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DemoCRPushModel.Model;
using Dapper;

namespace DemoCRPushModel.Dao
{
    public interface ISiswaDao
    {
        IList<Siswa> GetAll();
    }

    public class SiswaDao : DbConfig, ISiswaDao
    {
        public IList<Siswa> GetAll()
        {
            IList<Siswa> recordSiswa = null;

            var sql = @"select nis, nama, alamat
                        from siswa
                        order by nama";

            recordSiswa = conn.Query<Siswa>(sql)
                              .ToList();

            return recordSiswa;
        }
        
    }
}
