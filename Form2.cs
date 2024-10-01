using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapB3
{
    public partial class frmForm2 : Form
    {
        public frmForm2()
        {
            InitializeComponent();
        }

        // Định nghĩa delegate
        public delegate void SendDataDelegate(string maSo, string hoTen, string luong);

        // Định nghĩa sự kiện
        public event SendDataDelegate OnSendData;

        private void btnDongY_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ các TextBox
            string maSo = txtMaSo.Text;
            string hoTen = txtHoTen.Text;
            string luong = txtLuong.Text;

            // Gọi sự kiện để gửi dữ liệu
            OnSendData?.Invoke(maSo, hoTen, luong);

            // Đóng frmForm2 sau khi gửi dữ liệu
            this.Close();
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            // Hiển thị MessageBox để xác nhận việc thoát
            DialogResult result = MessageBox.Show("Bạn có muốn thoát?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            // Kiểm tra kết quả của MessageBox
            if (result == DialogResult.OK)
            {
                // Đóng frmForm2 nếu người dùng chọn OK
                this.Close();
            }
            // Nếu người dùng chọn Cancel, không làm gì cả và quay lại form
        }
    }
}
