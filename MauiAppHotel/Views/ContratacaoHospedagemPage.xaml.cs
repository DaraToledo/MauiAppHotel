using MauiAppHotel.Models;
using System;
using System.Collections.Generic;
using Microsoft.Maui.Controls;

namespace MauiAppHotel.Views
{
    public partial class ContratacaoHospedagemPage : ContentPage
    {
        List<Quarto> lista_quartos = new List<Quarto>
        {
            new Quarto { Descricao = "Suíte Luxo", ValorDiariaAdulto = 250.0, ValorDiariaCrianca = 100.0 },
            new Quarto { Descricao = "Suíte Executiva", ValorDiariaAdulto = 180.0, ValorDiariaCrianca = 80.0 },
            new Quarto { Descricao = "Suíte Single", ValorDiariaAdulto = 100.0, ValorDiariaCrianca = 50.0 }
        };

        public ContratacaoHospedagemPage()
        {
            InitializeComponent();
            pck_quarto.ItemsSource = lista_quartos;

            dtp_checkin.MinimumDate = DateTime.Now;
            dtp_checkin.MaximumDate = DateTime.Now.AddMonths(6);
            dtp_checkout.MinimumDate = DateTime.Now.AddDays(1);
            dtp_checkout.MaximumDate = DateTime.Now.AddMonths(6);
        }

        private void StpAdultos_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            lbl_adultos.Text = e.NewValue.ToString();
        }

        private void StpCriancas_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            lbl_criancas.Text = e.NewValue.ToString();
        }

        private void DtpCheckin_DateSelected(object sender, DateChangedEventArgs e)
        {
            if (dtp_checkin.Date.HasValue)
            {
                dtp_checkout.MinimumDate = dtp_checkin.Date.Value.AddDays(1);
            }
        }

        private async void BtnAvancar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var h = new Hospedagem
                {
                    QuartoSelecionado = (Quarto)pck_quarto.SelectedItem,
                    QtdAdultos = Convert.ToInt32(lbl_adultos.Text),
                    QtdCriancas = Convert.ToInt32(lbl_criancas.Text),
                    DataCheckIn = dtp_checkin.Date ?? DateTime.Now,
                    DataCheckOut = dtp_checkout.Date ?? DateTime.Now.AddDays(1)
                };

                if (h.QuartoSelecionado == null)
                {
                    await DisplayAlert("Erro", "Por favor, selecione uma suíte.", "OK");
                    return;
                }

                await DisplayAlert("Sucesso", $"Hospedagem para {h.QuartoSelecionado.Descricao} calculada: Total R$ {h.ValorTotal}", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "OK");
            }
        }

        private async void BtnSobre_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SobrePage());
        }
    }
}