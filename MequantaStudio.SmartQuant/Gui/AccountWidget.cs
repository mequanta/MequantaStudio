using System;
using SmartQuant;

namespace MequantaStudio.SmartQuant
{
    public partial class AccountWidget : Gtk.Bin
    {
        public AccountWidget()
        {
            this.Build();

            foreach (var snapshot in Framework.Current.AccountDataManager.GetSnapshots())
            {
                foreach (var entry in snapshot.Entries)
                {
                    this.AddAccountData(entry.Values);
                    foreach (var data in entry.Positions)
                        this.AddAccountData(data);
                    foreach (var data in entry.Orders)
                        this.AddAccountData(data);
                }
            }
        }

        private void AddAccountData(AccountData data)
        {
        }
    }
}

