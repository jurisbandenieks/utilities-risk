namespace Api.Models;

public enum TradeDirection { Buy, Sell }
public enum TradeStatus { Pending, Confirmed, Cancelled }
public enum RiskSeverity { Low, Medium, High }
public enum MarketStatus { Active, Halted }
public enum UserStatus { Active, Inactive }
public enum UserRole { Trader, RiskManager, ComplianceOfficer, Admin }
public enum AlertStatus { Active, Triggered, Dismissed }
