import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { map } from "rxjs/operators";
import { MutationDto } from "src/app/dtos/mutation.dto";
import { MutationService } from "src/app/services/mutation.service";

@Component({
  selector: "app-mutation-detail",
  templateUrl: "./mutation-detail.component.html",
  styleUrls: ["./mutation-detail.component.scss"]
})
export class MutationDetailComponent implements OnInit {
  mutation: MutationDto;
  mutationId: number;

  constructor(
    private route: ActivatedRoute,
    private mutationService: MutationService
  ) {}

  ngOnInit() {
    this.getRouteParameter();
    this.getMutation();
  }

  getRouteParameter() {
    this.route.paramMap
      .pipe(map(params => params.get("mutationId")))
      .subscribe(m => (this.mutationId = +m));
  }

  getMutation() {
    this.mutationService
      .getMutation(this.mutationId)
      .subscribe(m => (this.mutation = m));
  }
}
