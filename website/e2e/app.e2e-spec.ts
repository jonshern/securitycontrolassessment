import { SecuritycontrolassessmentwebsitePage } from './app.po';

describe('securitycontrolassessmentwebsite App', function() {
  let page: SecuritycontrolassessmentwebsitePage;

  beforeEach(() => {
    page = new SecuritycontrolassessmentwebsitePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
