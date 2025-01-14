using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUẢN_LÍ_DOANH_THU
{
    class QuanLyDoanhThu
    {
        private string __tenCauLacBo;
        private string __tenNuoc;
        private int __soLuongVe;
        private double __giaVe;

        public QuanLyDoanhThu()
        {
        }

        public QuanLyDoanhThu(string tenCauLacBo, string tenNuoc, int soLuongVe, double giaVe)
        {
            __tenCauLacBo = tenCauLacBo;
            __tenNuoc = tenNuoc;
            __soLuongVe = soLuongVe;
            __giaVe = giaVe;
        }

        public string TenCauLacBo { get => __tenCauLacBo; set => __tenCauLacBo = value; }
        public string TenNuoc { get => __tenNuoc; set => __tenNuoc = value; }
        public int SoLuongVe { get => __soLuongVe; set => __soLuongVe = value; }
        public double GiaVe { get => __giaVe; set => __giaVe = value; }

        public double DoanhThu()
        {
            return GiaVe*SoLuongVe;
        }
    }
}
