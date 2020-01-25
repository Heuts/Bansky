import { Component, OnInit } from "@angular/core";
import { MutationService } from "src/app/services/mutation.service";
import { MutationDTO } from "src/app/dtos/mutation.dto";

@Component({
  selector: "app-mutation-overview",
  templateUrl: "./mutation-overview.component.html",
  styleUrls: ["./mutation-overview.component.css"]
})
export class MutationOverviewComponent implements OnInit {
  public mutations: MutationDTO[];
  private isLoading: boolean;

  constructor(private mutationService: MutationService) {}

  ngOnInit() {
    this.isLoading = true;
    this.mutationService.getAllMutations().subscribe(m => {
      this.mutations = this.mutationService.sortByDate(m);
      this.isLoading = false;
    });
  }
}
