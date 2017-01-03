using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebForm1 : System.Web.UI.Page
{
    static ArrayList receipts = new ArrayList();
    string vehicle;
    protected void Page_Load(object sender, EventArgs e)
    {
        vehicle = tb_vn.Text.ToString();
        
        //clear history in the receipts when first load in this page 
        if (!IsPostBack)
        {
            receipts.Clear();
        }
    }

    protected void add_btn_Click(object sender, EventArgs e)
    {
        //Bind to GridView1
        Receipt r = new Receipt();
        r.Shop = tb_receipt.Text.ToString();
        r.Receipt_sn = tb_sn.Text.ToString();
        r.Amount = Convert.ToDouble(tb_amount.Text.ToString());
        receipts.Add(r);

        GridView1.DataSource = receipts;
        GridView1.DataBind();

        //get dataset
        dsVehicleRb ds = new dsVehicleRb();
        dsVehicleRbTableAdapters.vehicleRbTableAdapter ad =
            new dsVehicleRbTableAdapters.vehicleRbTableAdapter();
        ad.Fill(ds.vehicleRb);

        //update existingDebate
        for (int i = 0; i < ds.vehicleRb.Count; i++)
        {
            if (vehicle == ds.vehicleRb.Rows[i][0].ToString())
            {
                ds.vehicleRb.Rows[i][1] =
                    Convert.ToDouble(ds.vehicleRb.Rows[i][1].ToString()) + r.Amount;
                ad.Update(ds.vehicleRb);
                break;
            }
        }

        //refresh existingRebate textbox
        tb_er.Text = findExistingRebate().ToString();
        tb_rt.Text = null;
    }

    protected void btn_apply_Click(object sender, EventArgs e)
    {
        //calculate current rebate tickets
        int currentRebateTickets = applyRebates(vehicle, receipts);
        //dispaly on the rebate tickets textbox
        tb_rt.Text = currentRebateTickets.ToString();

        //refresh exiting rebate
        tb_er.Text = findExistingRebate().ToString();

        //refresh list and gridview
        applyRefresh(currentRebateTickets);
    }

    public void applyRefresh(int currentRebateTickets)
    {
        if (currentRebateTickets != 0)
        {
            receipts.Clear();
            GridView1.DataSource = receipts;
            GridView1.DataBind();

            tb_receipt.Text = null;
            tb_sn.Text = null;
            tb_amount.Text = null;
        }
       
    }
    
    public int applyRebates(string vehicle, ArrayList receipts)
    {
        //logic: ½ hour car-parking is credited to the shopper’s vehicle for every $25 spent on shopping accumulated in shopping receipts
        double appliedRebates = 0.0;
        //get existingRebate
        double exitingRebate = findExistingRebate();

        //calculate rebate tickets 
        int currentRebateTickets = Convert.ToInt16(Math.Floor(exitingRebate / 25));

        //apply to database
        //get dataset
        dsVehicleRb ds = new dsVehicleRb();
        dsVehicleRbTableAdapters.vehicleRbTableAdapter ad =
            new dsVehicleRbTableAdapters.vehicleRbTableAdapter();
        ad.Fill(ds.vehicleRb);

        //update existingDebate
        for (int i = 0; i < ds.vehicleRb.Count; i++)
        {
            if (vehicle == ds.vehicleRb.Rows[i][0].ToString())
            {
                appliedRebates = exitingRebate - currentRebateTickets * 25;
                ds.vehicleRb.Rows[i][1] = appliedRebates;
                ad.Update(ds.vehicleRb);
                break;
            }
        }
        return currentRebateTickets;
    }

    public dsVehicleRb useDataset()
    {
        //fill dataset
        dsVehicleRb ds = new dsVehicleRb();
        dsVehicleRbTableAdapters.vehicleRbTableAdapter ad =
            new dsVehicleRbTableAdapters.vehicleRbTableAdapter();
        ad.Fill(ds.vehicleRb);
        return ds;
    }
    protected void bt_find_Click(object sender, EventArgs e)
    {
        tb_er.Text = findExistingRebate().ToString();
    }

    public double findExistingRebate()
    {
        dsVehicleRb ds = useDataset();

        //find and return
        double existingRebate = 0.0;
        for (int i = 0; i < ds.vehicleRb.Count; i++)
        {
            if (vehicle == ds.vehicleRb.Rows[i][0].ToString())
            {
                existingRebate = (double)ds.vehicleRb.Rows[i][1];
                break;
            }
        }
        return existingRebate;

        //another way to find
        // var q = ds.vehicleRb.Where(x => x.vehicleNum == vehicle).ToList();
        ////double stingRb= q.Select(y => y.existingRebates);
        //GridView2.DataSource = q;
        //GridView2.DataBind();
    }
}