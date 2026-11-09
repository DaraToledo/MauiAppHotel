using System;

namespace MauiAppHotel.Models
{
    public class Hospedagem
    {
        public Quarto QuartoSelecionado { get; set; }
        public int QtdAdultos { get; set; }
        public int QtdCriancas { get; set; }
        public DateTime DataCheckIn { get; set; }
        public DateTime DataCheckOut { get; set; }

        public int Stays => (DataCheckOut - DataCheckIn).Days;

        public double ValorTotal
        {
            get
            {
                if (QuartoSelecionado == null) return 0;

                double totalAdultos = QtdAdultos * QuartoSelecionado.ValorDiariaAdulto * Stays;
                double totalCriancas = QtdCriancas * QuartoSelecionado.ValorDiariaCrianca * Stays;

                return totalAdultos + totalCriancas;
            }
        }
    }
}