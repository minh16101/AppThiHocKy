using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_li_Lich_Thi.Class
{
    public enum METHOD
    {
        ADD, DELETE, REPAIR
    }
    public class list_view_method
    {
        //-----------------------------------LOPHOC-----------------------------------------//
        public static bool ListView_LOPHOC(METHOD method, ListView list_view, LopHoc lh)
        {
            if (list_view.Columns.Count == 4)
            {
                if (method == METHOD.ADD)
                {
                    foreach (ListViewItem x in list_view.Items)
                    {
                        if (x.SubItems[0].Text == lh.MLH.ToString())
                        {
                            return false;
                        }
                    }
                    string[] arr = { lh.MLH.ToString(), lh.TenLH, lh.MSGV.ToString(), lh.MHP };
                    ListViewItem item = new ListViewItem(arr);
                    list_view.Items.Add(item);
                    return true;
                }
                else if (method == METHOD.REPAIR)
                {
                    ListViewItem items = new ListViewItem();
                    bool find = false;
                    foreach (ListViewItem item in list_view.Items)
                    {
                        if (item.SubItems[0].Text == lh.MLH.ToString())
                        {
                            items = item;
                            find = true;
                        }
                    }
                    if (find == true)
                    {
                        list_view.Items.Remove(items);
                        string[] arr = { lh.MLH.ToString(), lh.TenLH, lh.MSGV.ToString(), lh.MHP };
                        ListViewItem item_add = new ListViewItem(arr);
                        list_view.Items.Add(item_add);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    ListViewItem items = new ListViewItem();
                    bool find = false;
                    foreach (ListViewItem item in list_view.Items)
                    {
                        if (item.SubItems[0].Text == lh.MLH.ToString())
                        {
                            items = item;
                            find = true;
                        }
                    }
                    if (find == true)
                    {
                        list_view.Items.Remove(items);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
        }

        public static LopHoc ListView_GET_LOPHOC_SELECTED(ListView list_view)
        {
            LopHoc lh = new LopHoc();
            if (list_view.SelectedItems.Count == 1 && list_view.Columns.Count == 4)
            {
                lh.MLH = Convert.ToInt32(list_view.SelectedItems[0].SubItems[0].Text);
                lh.TenLH = list_view.SelectedItems[0].SubItems[1].Text;
                lh.MSGV = Convert.ToInt32(list_view.SelectedItems[0].SubItems[2].Text);
                lh.MHP = list_view.SelectedItems[0].SubItems[3].Text;
            }
            return lh;
        }

        public static ListViewItem ListView_GET_LOPHOC_EXIST(ListView list_view, string MLH)
        {
            foreach (ListViewItem item in list_view.Items)
            {
                if (item.Text == MLH)
                {
                    return item;
                }
            }
            return null;
        }

        //-----------------------------------LOPTHI----------------------------------------------//
        public static bool ListView_LOPTHI(METHOD method, ListView list_view, LopThi lt)
        {
            if (list_view.Columns.Count == 7)
            {
                if (method == METHOD.ADD)
                {
                    foreach (ListViewItem item in list_view.Items)
                    {
                        if (item.SubItems[0].Text == lt.MLT.ToString())
                        {
                            return false;
                        }
                    }
                    string[] arr = { lt.MLT.ToString(), lt.MLH.ToString(), lt.SoGV.ToString(), lt.TGT, lt.DDT, lt.Get_HTT(), lt.Get_KT() };
                    ListViewItem x = new ListViewItem(arr);
                    list_view.Items.Add(x);
                    return true;
                }
                else if (method == METHOD.DELETE)
                {
                    ListViewItem items = new ListViewItem();
                    bool find = false;
                    foreach (ListViewItem item in list_view.Items)
                    {
                        if (item.SubItems[0].Text == lt.MLT.ToString())
                        {
                            items = item;
                            find = true;
                        }
                    }
                    if (find == true)
                    {
                        list_view.Items.Remove(items);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    ListViewItem items = new ListViewItem();
                    bool find = false;
                    foreach (ListViewItem item in list_view.Items)
                    {
                        if (item.SubItems[0].Text == lt.MLT.ToString())
                        {
                            items = item;
                            find = true;
                        }
                    }
                    if (find == true)
                    {
                        list_view.Items.Remove(items);
                        string[] arr = { lt.MLT.ToString(), lt.MLH.ToString(), lt.SoGV.ToString(), lt.TGT, lt.DDT, lt.Get_HTT(), lt.Get_KT() };
                        ListViewItem item_add = new ListViewItem(arr);
                        list_view.Items.Add(item_add);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                return true;
            }
        }

        public static ListViewItem ListView_GET_LOPTHI_EXIST(ListView list_view, string MLT)
        {
            foreach (ListViewItem item in list_view.Items)
            {
                if (item.Text == MLT)
                {
                    return item;
                }
            }
            return null;
        }

        public static LopThi ListView_GET_LOPTHI_SELECTED(ListView list_view)
        {
            LopThi lt = new LopThi();
            if (list_view.SelectedItems.Count == 1 && list_view.Columns.Count == 7)
            {
                lt.MLT = Convert.ToInt32(list_view.SelectedItems[0].SubItems[0].Text);
                lt.MLH = Convert.ToInt32(list_view.SelectedItems[0].SubItems[1].Text);
                lt.SoGV = Convert.ToInt32(list_view.SelectedItems[0].SubItems[2].Text);
                lt.DDT = list_view.SelectedItems[0].SubItems[3].Text;
                lt.TGT = list_view.SelectedItems[0].SubItems[4].Text;
                lt.HTT = list_view.SelectedItems[0].SubItems[5].Text == "Online" ? Hinh_Thu_Thi.Online : Hinh_Thu_Thi.Offline;
                lt.KT = list_view.SelectedItems[0].SubItems[6].Text == "Giữa Kì" ? Kieu_Thi.Giua_Ki : Kieu_Thi.Cuoi_Ki;
            }
            return lt;
        }

        //----------------------------SINHVIEN------------------------------------------//
        public static bool ListView_SINHVIEN(METHOD method, ListView list_view, SinhVien sv)
        {
            if (list_view.Columns.Count == 2)
            {
                if (method == METHOD.ADD)
                {
                    foreach (ListViewItem x in list_view.Items)
                    {
                        if (x.SubItems[0].Text == sv.MSSV.ToString())
                        {
                            return false;
                        }
                    }
                    string[] arr = { sv.MSSV.ToString(), sv.TenSV };
                    ListViewItem item = new ListViewItem(arr);
                    list_view.Items.Add(item);
                    return true;
                }
                else if (method == METHOD.DELETE)
                {
                    ListViewItem items = new ListViewItem();
                    bool find = false;
                    foreach (ListViewItem item in list_view.Items)
                    {
                        if (item.SubItems[0].Text == sv.MSSV.ToString())
                        {
                            items = item;
                            find = true;
                        }
                    }
                    if (find == true)
                    {
                        list_view.Items.Remove(items);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    ListViewItem items = new ListViewItem();
                    bool find = false;
                    foreach (ListViewItem item in list_view.Items)
                    {
                        if (item.SubItems[0].Text == sv.MSSV.ToString())
                        {
                            items = item;
                            find = true;
                        }
                    }
                    if (find == true)
                    {
                        list_view.Items.Remove(items);
                        string[] arr = { sv.MSSV.ToString(), sv.TenSV };
                        ListViewItem item_add = new ListViewItem(arr);
                        list_view.Items.Add(item_add);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
        }

        public static bool ListView_GET_SINHVIEN_EXIST(ListView list_view, string MSSV)
        {
            foreach (ListViewItem item in list_view.Items)
            {
                if (item.Text == MSSV)
                {
                    return true;
                }
            }
            return false;
        }

        public static SinhVien ListView_GET_SINHVIEN_SELECTED(ListView list_view)
        {
            SinhVien sv = new SinhVien();
            if (list_view.SelectedItems.Count == 1 && list_view.Columns.Count == 2)
            {
                sv.MSSV = Convert.ToInt32(list_view.SelectedItems[0].Text);
                sv.TenSV = list_view.SelectedItems[0].SubItems[0].Text;
            }
            return sv;
        }

        //----------------------------GIANGVIEN------------------------------------------//
        public static bool ListView_GIANGVIEN(METHOD method, ListView list_view, GiangVien gv)
        {
            if (list_view.Columns.Count == 3)
            {
                if (method == METHOD.ADD)
                {
                    foreach (ListViewItem x in list_view.Items)
                    {
                        if (x.SubItems[0].Text == gv.MSGV.ToString())
                        {
                            return false;
                        }
                    }
                    string[] arr = { gv.MSGV.ToString(), gv.TenGV, gv.Khoa };
                    ListViewItem item = new ListViewItem(arr);
                    list_view.Items.Add(item);
                    return true;
                }
                else if (method == METHOD.DELETE)
                {
                    ListViewItem items = new ListViewItem();
                    bool find = false;
                    foreach (ListViewItem item in list_view.Items)
                    {
                        if (item.SubItems[0].Text == gv.MSGV.ToString())
                        {
                            items = item;
                            find = true;
                        }
                    }
                    if (find == true)
                    {
                        list_view.Items.Remove(items);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    ListViewItem items = new ListViewItem();
                    bool find = false;
                    foreach (ListViewItem item in list_view.Items)
                    {
                        if (item.SubItems[0].Text == gv.MSGV.ToString())
                        {
                            items = item;
                            find = true;
                        }
                    }
                    if (find == true)
                    {
                        list_view.Items.Remove(items);
                        string[] arr = { gv.MSGV.ToString(), gv.TenGV, gv.Khoa };
                        ListViewItem item_add = new ListViewItem(arr);
                        list_view.Items.Add(item_add);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
        }

        public static ListViewItem ListView_GET_GIANGVIEN_EXIST(ListView list_view, string MSGV)
        {
            foreach (ListViewItem item in list_view.Items)
            {
                if (item.Text == MSGV)
                {
                    return item;
                }
            }
            return null;
        }

        public static GiangVien ListView_GET_GIANGVIEN_SELECTED(ListView list_view)
        {
            GiangVien gv = new GiangVien();
            if (list_view.SelectedItems.Count == 1 && list_view.Columns.Count == 3)
            {
                gv.MSGV = Convert.ToInt32(list_view.SelectedItems[0].Text);
                gv.TenGV = list_view.SelectedItems[0].SubItems[0].Text;
                gv.Khoa = list_view.SelectedItems[0].SubItems[1].Text;
            }
            return gv;
        }
    }


}
