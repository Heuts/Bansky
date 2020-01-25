import { BrowserModule } from "@angular/platform-browser";
import { NgModule, APP_INITIALIZER } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { HttpClientModule } from "@angular/common/http";
import { RouterModule } from "@angular/router";
import { AppComponent } from "./app.component";
import { NavMenuComponent } from "./components/nav-menu/nav-menu.component";
import { HomeComponent } from "./components/home/home.component";
import { ConfigService } from "./services/config.service";
import { API_BASE_URL } from "./injection-tokens/api-base-url-token";
import { UploadService } from "./services/upload.service";
import { IconsModule } from "./icons/icons.module";
import { MutationOverviewComponent } from './components/mutation-overview/mutation-overview.component';

export function init(configService: ConfigService): Function {
  return () => {
    const cachePromise = configService.loadCache();
    return Promise.all([cachePromise]);
  };
}

export function getApiBaseUrlFactory(configService: ConfigService) {
  return configService.getCachedConfig().apiServerUrl;
}

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    MutationOverviewComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: "ng-cli-universal" }),
    HttpClientModule,
    FormsModule,
    IconsModule,
    RouterModule.forRoot([
      { path: "", component: HomeComponent, pathMatch: "full" },
    ])
  ],
  providers: [
    ConfigService,
    UploadService,
    {
      provide: API_BASE_URL,
      useFactory: getApiBaseUrlFactory,
      deps: [ConfigService]
    },
    {
      provide: APP_INITIALIZER,
      useFactory: init,
      deps: [ConfigService],
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}
