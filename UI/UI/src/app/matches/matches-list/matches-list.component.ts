import { Component, OnInit } from '@angular/core';
import { Match } from '../../models/Match';
import { MatchService } from '../../services/match.service';

@Component({
  selector: 'app-matches-list',
  templateUrl: './matches-list.component.html',
  styleUrls: ['./matches-list.component.css']
})
export class MatchesListComponent implements OnInit {
  matches: Match[] = [];
  constructor(private matchService: MatchService) { }

  ngOnInit(): void {
    this.loadMatches();
  }

  loadMatches() {
    this.matchService.getMatches().subscribe((matches: Match[]) => {
      this.matches = matches;
    })
  }
}
