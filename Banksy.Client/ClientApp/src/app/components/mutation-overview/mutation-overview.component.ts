import { Component, OnInit } from "@angular/core";
import { MutationService } from "src/app/services/mutation.service";
import { MutationDto } from "src/app/dtos/mutation.dto";
import { Router } from "@angular/router";

@Component({
  selector: "app-mutation-overview",
  templateUrl: "./mutation-overview.component.html",
  styleUrls: ["./mutation-overview.component.css"]
})
export class MutationOverviewComponent implements OnInit {
  public mutations: MutationDto[];
  private isLoading: boolean;
  itemsPerPage: number = 10;
  totalItems: number;
  page: number = 1;
  previousPage: number;

  constructor(private mutationService: MutationService, private route: Router) { }

  ngOnInit(): void {
    this.loadMutations();
    this.getTotalMutations();
  }

  getTotalMutations() {
    this.mutationService
      .getTotalMutations()
      .subscribe(m => this.totalItems = m);
  }

  private loadMutations(): void {
    this.isLoading = true;
    this.mutationService
      .getMutationsByPageAndSize(
        this.page,
        this.itemsPerPage,
      )
      .subscribe(m => {
        this.mutations = m;
        this.isLoading = false;
      });
  }

  loadPage(page) {
    if (page !== this.previousPage) {
      this.previousPage = page;
      this.loadMutations();
    }
  }

  sliceDescription(str: string) {
    const maxLength: number = 100;
    if (str.length > maxLength) {
      return str.slice(0, maxLength).trim() + '...';
    } else {
      return str;
    }
  }

  sliceName(str: string) {
    const maxLength: number = 25;
    if (str.length > maxLength) {
      return str.slice(0, maxLength).trim() + '...';
    } else {
      return str;
    }
  }

  navigateToMutationDetail(id: number) {
    this.route.navigateByUrl(`mutation-detail/` + id);
  }
}
