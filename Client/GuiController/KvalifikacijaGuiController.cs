using Client.UserControls;
using Common.Domain;

namespace Client.GuiController
{
    /// <summary>
    /// Kontroler korisnickog interfejsa za SK21 - Ubaci kvalifikaciju.
    /// </summary>
    public class KvalifikacijaGuiController
    {
        private UCUbaciKvalifikaciju uc;

        internal Control CreateUbaciKvalifikaciju()
        {
            uc = new UCUbaciKvalifikaciju();
            uc.btnUbaci.Click += UbaciKvalifikaciju;
            return uc;
        }

        /// <summary>
        /// Koraci 3 do 5 scenarija SK21.
        /// </summary>
        private void UbaciKvalifikaciju(object sender, EventArgs e)
        {
            if (!uc.Validacija())
            {
                MessageBox.Show("Molimo popunite sva polja",
                    "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Kvalifikacija kvalifikacija = new Kvalifikacija
            {
                Naziv = uc.cmbNaziv.SelectedItem.ToString(),
                NivoStrucnosti = uc.cmbNivoStrucnosti.SelectedItem.ToString()
            };

            try
            {
                Communication.Instance.UbaciKvalifikacija(kvalifikacija);
            }
            catch (Exception)
            {
                MessageBox.Show("Sistem ne moze da zapamti kvalifikaciju",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show($"Sistem je zapamtio kvalifikaciju: {kvalifikacija}",
                "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Information);

            uc.Ocisti();
        }

        internal void HandleClose()
        {
            // Ovaj slucaj koriscenja ne pravi privremene slogove u bazi.
        }
    }
}
