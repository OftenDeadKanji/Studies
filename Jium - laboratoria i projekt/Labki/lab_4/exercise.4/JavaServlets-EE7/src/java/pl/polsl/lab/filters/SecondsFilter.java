package pl.polsl.lab.filters;

import java.io.IOException;
import java.util.Calendar;
import java.util.GregorianCalendar;
import javax.servlet.Filter;
import javax.servlet.FilterChain;
import javax.servlet.FilterConfig;
import javax.servlet.ServletException;
import javax.servlet.ServletRequest;
import javax.servlet.ServletResponse;
import javax.servlet.annotation.WebFilter;
import javax.servlet.annotation.WebInitParam;

@WebFilter(filterName = "SecondsFilter",
        urlPatterns = {"/*"},
        initParams = {
            @WebInitParam(name = "mood", value = "awake")})
public class SecondsFilter implements Filter {

    String mood = null;

    @Override
    public void init(FilterConfig filterConfig) throws ServletException {
        mood = filterConfig.getInitParameter("mood");
    }

    @Override
    public void doFilter(ServletRequest req,
            ServletResponse res,
            FilterChain chain) throws IOException, ServletException {
        Calendar cal = GregorianCalendar.getInstance();
        switch (cal.get(Calendar.SECOND)/10) {
            case 0:
                mood = "sleepy";
                break;
            case 1:
                mood = "hungry";
                break;
            case 2:
                mood = "alert";
                break;
            case 3:
                mood = "in need of coffee";
                break;
            case 4:
                mood = "thoughtful";
                break;
            default:
                mood = "lethargic";
                break;
                
        }
        req.setAttribute("mood", mood);
        chain.doFilter(req, res);
    }

    @Override
    public void destroy() {
    }
}
