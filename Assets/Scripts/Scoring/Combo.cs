public class Combo
{
  private int combo = 1;
  //Ajoute 1 au combo
  public void IncCombo()
  {
    combo += 1;
    if (combo > 5)
    {
      combo = 5;
    }
  }

  public int GetCombo()
  {
    return combo;
  }

  public void ResetCombo()
  {
    combo = 1;
  }
}
