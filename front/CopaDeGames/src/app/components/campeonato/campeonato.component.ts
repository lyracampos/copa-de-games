import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Competidores } from 'src/app/models/competidor.model';
import { CopaDeGamesService } from 'src/app/services/copa-de-games.service';


@Component({
  selector: 'app-campeonato',
  templateUrl: './campeonato.component.html',
  styleUrls: ['./campeonato.component.css']
})
export class CampeonatoComponent implements OnInit {

  competidores: Competidores;
  competidoresSelecionados: Array<string> = [];
  totalCompetidoresSelecionados: number = 0;
  selecionouCompetidores: boolean = true; 
  
  showCount:boolean = false;
  constructor(private copaDeGamesService: CopaDeGamesService, private router: Router) { }

  ngOnInit(): void {
    this.listCompetidoresApiLamda();
  }

  listCompetidoresApiLamda(): void{
    this.copaDeGamesService.getCompetidoresApiLambda().subscribe(
      data => {
        this.competidores = data;
      },
      error => { console.log(error); });
    }

    onChange(ev:any, id:string) {
      if (ev.target.checked) {
        this.competidoresSelecionados.push(id);
        this.totalCompetidoresSelecionados ++;
        this.selecionouCompetidores = this.totalCompetidoresSelecionados == 8 ? true : false;
      } else {
        const index: number = this.competidoresSelecionados.indexOf(id);
        this.competidoresSelecionados.splice(index, 1);
        this.totalCompetidoresSelecionados --;
        this.selecionouCompetidores = this.totalCompetidoresSelecionados == 8 ? true : false;
      }
    }

    submit(): void {
      this.copaDeGamesService.iniciarCampeonato(this.competidoresSelecionados).subscribe(
        data => {
          this.router.navigate(['/campeoes', data.id]);
        },
        error => {
          console.log(error);
        });
    }
}
