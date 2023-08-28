import './App.css'
import { NavigationMenu, NavigationMenuList, NavigationMenuItem } from '@/components/ui/navigation-menu'
import { Outlet, Link } from "react-router-dom";

function App() {

  return (
    <>
      <NavigationMenu>
        <NavigationMenuList>
          <NavigationMenuItem>
            <h1>Templatodo 📆</h1>
          </NavigationMenuItem>
          <NavigationMenuItem>
            <Link to={'/today'}>Today</Link>
          </NavigationMenuItem>
        </NavigationMenuList>
      </NavigationMenu>
      <Outlet />
    </>
  )
}

export default App
