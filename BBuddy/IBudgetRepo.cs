using System.Collections.Generic;

namespace BBuddy
{
    public interface IBudgetRepo
    {
        List<Budget> GetAll();
    }
}