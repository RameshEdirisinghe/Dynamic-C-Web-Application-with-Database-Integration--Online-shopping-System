
# Online Shopping Cart System

An advanced, scalable, and intuitive **Online Shopping Cart System** designed to simplify the shopping experience for customers and streamline store management for admins. This project integrates robust back-end functionality with a responsive front-end to provide a seamless e-commerce experience.



## Features

### Customer Features

- **User Registration & Authentication**: Secure sign-up and login functionality with data validation.
- **Product Browsing and Search**: Simple navigation through the product catalog with category filtering and keyword search.
- **Shopping Cart**: Add, update, and remove items from a cart that reflects the total amount dynamically.
- **Order History & Tracking**: View previous orders and track current ones.
- **Wishlist**: Add favorite products to a wishlist for easy access later.

### Admin Features

- **Product Management**: Add, update, and delete products, manage categories, and adjust inventory.
- **User Management**: View and manage user accounts with permissions and restrictions.
- **Order Management**: Monitor and manage orders with status updates.
- **Dashboard Analytics**: Overview of sales, inventory, and user activity.

## Technologies Used

- **Back-End**: 
  - *C#* - The core application logic.
  - *SQL* - Database management, optimized for faster querying and indexing.
- **Front-End**:
  - *HTML & CSS* - User-friendly interface design.
  - *JavaScript* - Dynamic interactions and real-time cart updates.
- **Integration**:
  - *PHP* - Middleware for connecting front-end and back-end.

## Setup & Installation

### Prerequisites
- Visual Studio (with .NET support)
- SQL Server for database management
- Web server (IIS or alternatives)

### Installation Steps
1. **Clone the Repository**:
   ```bash
   git clone <repository-url>
   ```
2. **Open Project**:
   Open the solution file `OnlineShoppingSystem.sln` in Visual Studio.
3. **Configure Database**:
   - Set up the SQL database with the provided schema (`/database/schema.sql`).
   - Update database connection strings in the configuration file.
4. **Run the Application**:
   Build and run the project in Visual Studio.

## Usage Guide

1. **User Registration**:
   - Sign up as a new user to access the shopping platform.
2. **Product Browsing**:
   - Search or browse through categories to find products.
3. **Shopping Cart**:
   - Add items to your cart, view total costs, and proceed to checkout.
4. **Order Management**:
   - Users can track order statuses; admins can update order statuses.
5. **Admin Dashboard**:
   - Admins log in to manage products, users, and view analytics.

## Project Structure

- `/OnlineShoppingSystem` - Core project files.
- `/database` - SQL database schema and initial setup scripts.
- `README.md` - Project documentation.

## Contributing

We welcome contributions! To contribute:
1. Fork the repository.
2. Create a new branch for your feature or bug fix.
3. Submit a pull request detailing the changes.

## License

This project is licensed under the MIT License. See the `LICENSE` file for details.


