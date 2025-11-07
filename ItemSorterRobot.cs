using System;
using System.Text;

namespace Week6InventorySystem;

// Simple "pick item and drop in shipment box" robot + grid demo
public class ItemSorterRobot : Robot
{
    // ====== Part A: Picking items to the shipment box (from previous step) ======
    public const string UrscriptTemplate = @"
def move_item_to_shipment_box():
  # demo coords (meters)
  SBOX_X = 3
  SBOX_Y = 3
  ITEM_X = {0}
  ITEM_Y = 1
  DOWN_Z = 0.10

  def moveto(x, y, z = 0.20):
    # placeholder (your real program would do movej here)
    textmsg(""Moving to "", x, y, z)
  end

  # go above item, down, up, then to shipment box
  moveto(ITEM_X, ITEM_Y, 0.20)
  moveto(ITEM_X, ITEM_Y, DOWN_Z)
  moveto(ITEM_X, ITEM_Y, 0.20)
  moveto(SBOX_X, SBOX_Y, 0.20)
end
";

    // Convert an inventory slot (1,2,3,...) to X position. Spacing = 0.1 m
    public double XFromInventoryLocation(uint slot)
    {
        return Math.Round(slot * 0.1, 3);
    }

    public void PickUp(uint inventoryLocation)
    {
        var x = XFromInventoryLocation(inventoryLocation);
        var program = string.Format(UrscriptTemplate, x);
        SendUrscript(program);
    }

    // ====== Part B: Activity 44 – move to points on a grid ======

    // URScript program that moves the tool to a list of integer grid points (x,y)
    // using the given origin and spacing (meters). Z_SAFE keeps the tool above the table.
    public void SendMoveProgramForPoints((int x, int y)[] points)
    {
        const double X_ORIGIN = 0.0; // from the course example
        const double Y_ORIGIN = -0.4; // from the course example
        const double Z_SAFE = 0.20; // tool height (m) above the plane
        const double SPACING = 0.10; // 10 cm grid spacing

        var sb = new StringBuilder();
        sb.AppendLine("def f():");
        // Move to a default joint position first (from the notes)
        sb.AppendLine("  movej([0, d2r(-90), 0, d2r(-90), 0, 0])");
        sb.AppendLine($"  X_ORIGIN = {X_ORIGIN}");
        sb.AppendLine($"  Y_ORIGIN = {Y_ORIGIN}");
        sb.AppendLine($"  Z_SAFE = {Z_SAFE}");
        sb.AppendLine($"  SPACING = {SPACING}");

        sb.AppendLine("  def move_xy(ix, iy):");
        sb.AppendLine("    px = X_ORIGIN + ix * SPACING");
        sb.AppendLine("    py = Y_ORIGIN + iy * SPACING");
        sb.AppendLine("    p1 = p[px, py, Z_SAFE, 0, d2r(180), 0]");
        sb.AppendLine("    movej(p1)");
        sb.AppendLine("  end");

        foreach (var (x, y) in points)
            sb.AppendLine($"  move_xy({x}, {y})");

        sb.AppendLine("end");

        SendUrscript(sb.ToString());
    }

    // Helper to send the specific path a -> b -> c -> d from the lecture graphic
    // a(1,1), b(3,3), c(3,1), d(2,3)  (based on the shown grid)
    public void SendDemoPathAtoBtoCtoD()
    {
        var pts = new (int x, int y)[] { (1, 1), (3, 3), (3, 1), (2, 3) };
        SendMoveProgramForPoints(pts);
    }
}