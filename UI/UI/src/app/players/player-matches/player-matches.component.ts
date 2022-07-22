import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Match } from 'src/app/models/Match';
import { PlayerService } from 'src/app/services/player.service';

@Component({
  selector: 'app-player-matches',
  templateUrl: './player-matches.component.html',
  styleUrls: ['./player-matches.component.css']
})
export class PlayerMatchesComponent implements OnInit {
  matches: Match[] = [];
  constructor(private playerService: PlayerService, private activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.loadMatches();
  }

  loadMatches() {
    this.playerService.getPlayersMatches(this.activatedRoute.snapshot.paramMap.get('username')!).subscribe((matches: Match[]) => {
      this.matches = matches;
    })
  }
}
