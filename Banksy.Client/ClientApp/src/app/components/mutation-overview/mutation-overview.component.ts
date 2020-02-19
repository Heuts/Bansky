import { Component, OnInit } from "@angular/core";
import { MutationService } from "src/app/services/mutation.service";
import { MutationDto } from "src/app/dtos/mutation.dto";
import { Router } from "@angular/router";
import { Observable, timer, merge, combineLatest } from "rxjs";
import { mapTo, takeUntil } from "rxjs/operators";

@Component({
  selector: "app-mutation-overview",
  templateUrl: "./mutation-overview.component.html",
  styleUrls: ["./mutation-overview.component.scss"]
})
export class MutationOverviewComponent implements OnInit {
  public mutations: MutationDto[];
  showSpinner: boolean;
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
    const miliSecDelayBeforeSpinning = 500;
    const miliSecMinimalSpinningTime = 1000;

    const mutations$: Observable<MutationDto[]> =
      this.mutationService
        .getMutationsByPageAndSize(
          this.page,
          this.itemsPerPage,
        );

    const showLoadingIndicator$ =
      merge(
        timer(miliSecDelayBeforeSpinning)
          .pipe(mapTo(true), // turn the value into `true`, meaning loading is shown
            takeUntil(mutations$)), // emit only if result$ wont emit before 500ms
        combineLatest(mutations$, timer(miliSecMinimalSpinningTime))
          .pipe(mapTo(false)));  // value 'false' once we receive a result, yet at least show 1000ms

    mutations$.subscribe(mutations => {
      this.mutations = mutations;
    });

    showLoadingIndicator$.subscribe(isLoading => {
      this.showSpinner = isLoading;
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
