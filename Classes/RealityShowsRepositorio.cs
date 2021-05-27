using System;
using System.Collections.Generic;
using DIO.RealityShows.Interfaces;

namespace DIO.RealityShows
{
	public class RealityShowsRepositorio : IRepositorio<RealityShows>
	{
        private List<RealityShows> listaRealityShows = new List<RealityShows>();
		public void Atualiza(int Id, RealityShows Objeto)
		{
			listaRealityShows[Id] = Objeto;
		}

		public void Exclui(int Id)
		{
			listaRealityShows[Id].Excluir();
		}

		public void Insere(RealityShows Objeto)
		{
			listaRealityShows.Add(Objeto);
		}

		public List<RealityShows> Lista()
		{
			return listaRealityShows;
		}

		public int ProximoId()
		{
			return listaRealityShows.Count;
		}

		public RealityShows RetornaPorId(int Id)
		{
			return listaRealityShows[Id];
		}
	}
}