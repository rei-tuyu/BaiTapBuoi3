using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace BaiTapB3
{
    public partial class frmForm1 : Form
    {
        public frmForm1()
        {
            InitializeComponent();
        }
        // Thêm một nhân viên vào DataGridView
        private void btnThem_Click(object sender, EventArgs e)
        {
            // Tạo một instance của frmForm2
            frmForm2 frm2 = new frmForm2();

            // Đăng ký sự kiện OnSendData
            frm2.OnSendData += new frmForm2.SendDataDelegate(AddDataToGridView);

            // Thiết lập frmForm1 là form cha của frmForm2
            frm2.Owner = this;

            // Hiển thị frmForm2 dưới dạng hộp thoại
            frm2.ShowDialog();
        }
        // Hàm xử lý dữ liệu nhận được từ frmForm2
        private void AddDataToGridView(string maSo, string hoTen, string luong)
        {
            // Tạo một mảng chứa dữ liệu
            string[] row = { maSo, hoTen, luong };

            // Thêm dữ liệu vào DataGridView
            dgvNhanVien.Rows.Add(row);
        }
        // Sửa nhân viên đã có trong DataGridWiew theo mã số
        private void btnSua_Click(object sender, EventArgs e)
        {
            // Tạo một instance của frmForm2
            frmForm2 frm2Update = new frmForm2();

            // Đăng ký sự kiện OnUpdateData
            frm2Update.OnSendData += new frmForm2.SendDataDelegate(UpdateDataInGridView);

            // Thiết lập frmForm1 là form cha của frmForm2
            frm2Update.Owner = this;

            // Hiển thị frmForm2 dưới dạng hộp thoại
            frm2Update.ShowDialog();
        }
        // Hàm xử lý dữ liệu nhận được từ frmForm2
        private void UpdateDataInGridView(string maSo, string hoTen, string luong)
        {
            // Tìm hàng có mã số nhân viên trùng khớp
            foreach (DataGridViewRow row in dgvNhanVien.Rows)
            {
                if (row.Cells[0].Value?.ToString() == maSo)
                {
                    // Cập nhật thông tin nhân viên
                    row.Cells[1].Value = hoTen;
                    row.Cells[2].Value = luong;
                    break;
                }
            }
        }
        // Xoá một nhân viên đã có trong DataGridView
        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có hàng nào được chọn trong DataGridView không
            if (dgvNhanVien.SelectedRows.Count > 0)
            {
                // Hiển thị MessageBox để xác nhận việc xóa
                DialogResult result = MessageBox.Show("Bạn có muốn xóa nhân viên này?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                // Kiểm tra kết quả của MessageBox
                if (result == DialogResult.OK)
                {
                    // Xóa hàng được chọn khỏi DataGridView
                    foreach (DataGridViewRow row in dgvNhanVien.SelectedRows)
                    {
                        dgvNhanVien.Rows.Remove(row);
                    }
                }
                // Nếu người dùng chọn Cancel, không làm gì cả và quay lại form
            }
            else
            {
                // Hiển thị thông báo nếu không có hàng nào được chọn
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            // Hiển thị MessageBox để xác nhận việc đóng form
            DialogResult result = MessageBox.Show("Bạn có muốn đóng Form?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            // Kiểm tra kết quả của MessageBox
            if (result == DialogResult.OK)
            {
                // Đóng frmForm1 nếu người dùng chọn OK
                this.Close();
            }
            // Nếu người dùng chọn Cancel, không làm gì cả và quay lại form
        }

        private void frmForm1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Hiển thị MessageBox để xác nhận việc đóng form
            DialogResult result = MessageBox.Show("Bạn có muốn đóng Form?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            // Kiểm tra kết quả của MessageBox
            if (result == DialogResult.Cancel)
            {
                // Hủy sự kiện đóng form nếu người dùng chọn Cancel
                e.Cancel = true;
            }
            // Nếu người dùng chọn OK, form sẽ đóng lại
        }
    }
}
