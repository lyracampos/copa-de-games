import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Competidores } from 'src/app/models/competidor.model';
import { CampeonatoService } from 'src/app/services/campeonato.service';
import { CompetidoresService } from 'src/app/services/competidores.service';

@Component({
  selector: 'app-fase-selecao',
  templateUrl: './fase-selecao.component.html',
  styleUrls: ['./fase-selecao.component.css']
})
export class FaseSelecaoComponent implements OnInit {

  competidores: Competidores;
  classificados: Array<string> = [];
  totalSelecionado: number = 0;
  validado: boolean = false;

  constructor(private competidoresService: CompetidoresService, private campeonatoService: CampeonatoService, private router: Router) { }

  ngOnInit(): void {
    this.listarCompetidores();
  }

  listarCompetidores(): void{
    this.competidoresService.list().subscribe(
      resp => { this.competidores = resp.sort((a,b) =>(a.titulo > b.titulo) ? 1: -1); },
      error => { console.log(error); });
  }

  selecionarCompetidor(ev:any, id:string) {
    if (ev.target.checked) {
      this.classificados.push(id);
      this.totalSelecionado ++;
      this.validado = this.totalSelecionado == 8 ? true : false;
    } else {
      const index: number = this.classificados.indexOf(id);
      this.classificados.splice(index, 1);
      this.totalSelecionado --;
      this.validado = this.totalSelecionado == 8 ? true : false;
    }
  }

  gerarCampeonato(): void {
    this.router.navigate(['/resultado-final']);

    this.campeonatoService.iniciarCampeonato(this.classificados).subscribe(
      resp => { this.router.navigate(['/resultado-final', resp.id]); console.log(this.classificados); },
      error => { console.log(error); });
  }
}
