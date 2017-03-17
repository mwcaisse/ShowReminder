import { Component, OnInit } from '@angular/core';

import { Show } from "./show";
import { ShowService } from "./show.service";

@Component({
    selector: 'my-app',
    templateUrl: "app/TestTemplate.html",
    styleUrls: ["app/TestStyles.css"],
    providers: [ShowService]
})
export class AppComponent implements OnInit {

    constructor(private showService: ShowService) {}

    shows: Show[];

    searchTerms: string;

    selectedShow: Show;

    collapsed = false;

    onSelect(show: Show): void {
        this.selectedShow = show;
    };

    searchShows(): void {
        this.showService.searchShows(this.searchTerms).then(shows => this.shows = shows);
    }

    ngOnInit(): void {
       
    }

    toggleCollapsed(): void {
        this.collapsed = !this.collapsed;
    }

    addShow(show: Show): void {
        this.showService.addShow(show.id).then(savedShow => console.log(savedShow));
    };

}
