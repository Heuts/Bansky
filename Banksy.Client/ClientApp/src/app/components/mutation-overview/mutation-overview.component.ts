import { Component, OnInit } from "@angular/core";
import { MutationService } from "src/app/services/mutation.service";
import { MutationDTO } from "src/app/dtos/mutation.dto";
import { map } from "rxjs/operators";

@Component({
  selector: "app-mutation-overview",
  templateUrl: "./mutation-overview.component.html",
  styleUrls: ["./mutation-overview.component.css"]
})
export class MutationOverviewComponent implements OnInit {
  public mutations: MutationDTO[];
  private isLoading: boolean;

  constructor(private mutationService: MutationService) {}

  ngOnInit(): void {
    this.loadMutations();
  }

  private loadMutations(): void {
    this.isLoading = true;
    this.mutationService
      .getAllMutations()
      .pipe(map(m => this.mutationService.sortByDate(m)))
      .subscribe(m => {
        this.mutations = m;
        this.isLoading = false;
      });
  }
}
