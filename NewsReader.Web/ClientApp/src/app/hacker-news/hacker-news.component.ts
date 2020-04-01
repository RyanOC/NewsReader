import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-hacker-news',
  templateUrl: './hacker-news.component.html',
  styleUrls: ['./hacker-news.component.css']
})
export class HackerNewsComponent {

  public loading = false;
  public hackerNewsItems: HackerNewsItem[];
  pageIndex: number = 0;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
  }

  ngOnInit() {
    this.fetchData();
  }

  fetchData() {
    this.loading = true;

    this.http.get<HackerNewsItem[]>(this.baseUrl + `api/newsreader/${this.pageIndex}`).subscribe(result => {

      if (this.hackerNewsItems===undefined) {
        this.hackerNewsItems = result;
      }
      else {
        this.hackerNewsItems = [...this.hackerNewsItems, ...result];
      }

      this.pageIndex++;
      this.loading = false;

    }, error => console.error(error));
  }

  loadMore() {
    this.fetchData();
  }

  getHostName(url) {
    if (url == null) return;
    var match = url.match(/:\/\/(www[0-9]?\.)?(.[^/:]+)/i);
    if (match != null && match.length > 2 && typeof match[2] === 'string' && match[2].length > 0) {
      return match[2];
    }
    else {
      return null;
    }
  }

  convert(unixtimestamp) {

    var months_arr = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'];

    // Convert timestamp to milliseconds
    var date = new Date(unixtimestamp * 1000);
    var year = date.getFullYear();
    var month = months_arr[date.getMonth()];
    var day = date.getDate();
    var hours = date.getHours();
    var minutes = "0" + date.getMinutes();
    var seconds = "0" + date.getSeconds();

    // Display date time in MM-dd-yyyy h:m:s format
    var convdataTime = month + '-' + day + '-' + year + ' ' + hours + ':' + minutes.substr(-2) + ':' + seconds.substr(-2);

    return convdataTime;
  }
}

interface HackerNewsItem {

  id: number;
  title: string;
  text: string;
  url: string;
  score: number;
  time: number;
  type: string;
}
