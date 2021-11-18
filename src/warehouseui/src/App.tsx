import {
  BrowserRouter as Router,
  Switch,
  Route,
  Link
} from "react-router-dom";
import './App.css';
import AddGood from "./components/Goods/AddGood";
import EditGood from "./components/Goods/EditGood";
import GoodsList from "./components/Goods/GoodsList";
import AddManufacturer from "./components/Manufactures/AddManufacturer";
import EditManufacturer from "./components/Manufactures/EditManufacturer";
import ManufacturersList from "./components/Manufactures/Manufacturers";


const App = () => {
  return (
    <div>
      <Router>
          <div className="container">
            <nav>
              <ul>
                <li>
                  <Link to="/goods">Товари</Link>
                </li>
                <li>
                  <Link to="/manufacturers">Виробники</Link>
                </li>
              </ul>
            </nav>
            
            <Switch>
              {/* <Route path="/">
                <h1>warehouse manager</h1>
              </Route> */}
              <Route path="/goods">
                <GoodsList />
              </Route>
              <Route path="/addGood">
                <AddGood />
              </Route>
              <Route path="/editGood/:goodId">
                <EditGood />
              </Route>
              <Route path="/manufacturers">
                <ManufacturersList />
              </Route>
              <Route path="/addManufacturer">
                <AddManufacturer />
              </Route>
              <Route path="/editManufacturer/:manufacturerId">
                <EditManufacturer />
              </Route>
            </Switch>
          </div>
        </Router>
    </div>
  );
};

export default App;
