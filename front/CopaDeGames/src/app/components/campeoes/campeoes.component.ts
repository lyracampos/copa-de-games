import { Component, OnInit } from '@angular/core';
import { CopaDeGamesService } from 'src/app/services/copa-de-games.service';
import { ActivatedRoute } from '@angular/router';
import { Campeonato } from 'src/app/models/campeonato.model';


@Component({
  selector: 'app-campeoes',
  templateUrl: './campeoes.component.html',
  styleUrls: ['./campeoes.component.css']
})
export class CampeoesComponent implements OnInit {

  public campeonato: Campeonato;

  constructor(private copaDeGamesService: CopaDeGamesService, private actRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.getCampeonato(); 
  }

  getCampeonato(): void{
    this.copaDeGamesService.getCampeonato(this.actRoute.snapshot.params.id).subscribe(
      data => {
        this.campeonato = data;
        console.log(this.campeonato);
      },
      error => { console.log(error); });
    }
}
