using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Quan_li_Lich_Thi.Class
{
    public enum METHOD_TREENODE
    {
        ADD,DELETE
    }
    public class tree_node_method
    {
        public static bool tree_node_Sinh_Vien(METHOD_TREENODE method,TreeView tree_view,SinhVien sv)
        {
            if(method == METHOD_TREENODE.ADD)
            {
                if (tree_node_exist_sinh_vien(tree_view, sv) == false)
                {
                    TreeNode item = new TreeNode();
                    item.Text = sv.MSSV.ToString();
                    item.Nodes.Add(sv.TenSV);
                    tree_view.Nodes.Add(item);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if(method == METHOD_TREENODE.DELETE)
            {
                int index = -1;
                for(int i = 0; i < tree_view.Nodes.Count; i++)
                {
                    if(tree_view.Nodes[i].Text == sv.MSSV.ToString())
                    {
                        index = i;
                    }
                }
                if (index != -1)
                {
                    tree_view.Nodes.RemoveAt(index);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false ;
            }
        }
        public static bool tree_node_delete_Node_Selected(TreeView tree_view)
        {
            if(tree_view.SelectedNode.Nodes.Count == 1)
            {
                tree_view.Nodes.Remove(tree_view.SelectedNode);
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool tree_node_exist_sinh_vien(TreeView tree_view, SinhVien sv)
        {
            foreach (TreeNode item in tree_view.Nodes)
            {
                if (item.Text == sv.MSSV.ToString())
                {
                    return true;
                }
            }
            return false;
        }

        public static List<SinhVien> Get_SinhVien_In_TreeView(TreeView treeview)
        {
            List<SinhVien> list_sv = new List<SinhVien>();
            if (treeview.Nodes.Count != 0)
            {
                foreach (TreeNode item in treeview.Nodes)
                {
                    SinhVien sv = new SinhVien();
                    sv.MSSV = Convert.ToInt32(item.Text);
                    sv.TenSV = item.Nodes[0].Text;
                    list_sv.Add(sv);
                }
            }
            return list_sv;
        }
        //----------------------------------------------------------------------------------------\\

        public static bool tree_node_exist_giang_vien(TreeView tree_view,GiangVien gv)
        {
            foreach(TreeNode item in tree_view.Nodes)
            {
                if(item.Text == gv.MSGV.ToString())
                {
                    return true;
                }
            }
            return false;
        }
        public static bool tree_node_Giang_Vien(METHOD_TREENODE method, TreeView tree_view, GiangVien gv)
        {
            if (method == METHOD_TREENODE.ADD)
            {
                if (tree_node_exist_giang_vien(tree_view,gv) == false)
                {
                    TreeNode item = new TreeNode();
                    item.Text = gv.MSGV.ToString();
                    item.Nodes.Add(gv.TenGV);
                    item.Nodes.Add(gv.Khoa);
                    tree_view.Nodes.Add(item);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (method == METHOD_TREENODE.DELETE)
            {
                int index = -1;
                for (int i = 0; i < tree_view.Nodes.Count; i++)
                {
                    if (tree_view.Nodes[i].Text == gv.MSGV.ToString())
                    {
                        index = i;
                    }
                }
                if (index != -1)
                {
                    tree_view.Nodes.RemoveAt(index);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        static public List<GiangVien> Get_GiangVien_In_TreeView(TreeView treeview)
        {
            List<GiangVien> list_gv = new List<GiangVien>();
            if (treeview.Nodes.Count != 0)
            {
                foreach (TreeNode item in treeview.Nodes)
                {
                    GiangVien gv = new GiangVien();
                    gv.MSGV = Convert.ToInt32(item.Text);
                    gv.TenGV = item.Nodes[0].Text;
                    gv.Khoa = item.Nodes[1].Text;
                    list_gv.Add(gv);
                }
            }
            return list_gv;
        }
    }
}
